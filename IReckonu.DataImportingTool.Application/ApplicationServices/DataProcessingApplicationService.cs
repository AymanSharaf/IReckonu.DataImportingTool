using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Domain;
using IReckonu.DataImportingTool.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class DataProcessingApplicationService : IDataProcessingApplicationService
    {
        private readonly IFileDeserialzer _fileDeserialzer;
        private readonly ISave _save;
        private readonly IGet _get;

        public DataProcessingApplicationService(IFileDeserialzer fileDeserialzer, ISave save, IGet get)
        {
            _fileDeserialzer = fileDeserialzer;
            _save = save;
            _get = get;
        }

        public async Task ProcessFile(string path)
        {
            var serilizedObjects = _fileDeserialzer.Deserialize(path);
            var targetGroups = new List<TargetGroup>();

            foreach (var serializedObject in serilizedObjects)
            {
                await ProcessImportDataFileInputRecord(targetGroups, serializedObject);
            }

            await SaveTargetGroups(targetGroups);

        }

        private async Task SaveTargetGroups(List<TargetGroup> targetGroups)
        {
            foreach (var targetGroup in targetGroups)
            {
                await _save.Save(targetGroup);
            }
        }

        private async Task ProcessImportDataFileInputRecord(List<TargetGroup> targetGroups, ImportDataFileInput input)
        {
            //Add decorator to IGet to cache the entities
            var targetGroup = await GetTargetGroup(targetGroups, input.Q1);

            var brand = await ProcessBrand(input.Description);
            var color = await ProcessColor(input.Color);
            var deliveryTime = await ProcessDeliveryTime(input.DeliveredIn);

            ProcessArticle(targetGroup, input.ColorCode, input.ArtikelCode, brand);

            ProcessProduct(targetGroup, input, color, deliveryTime, brand);

            if (targetGroups.All(a => a.Name != targetGroup.Name))
            {
                targetGroups.Add(targetGroup);
            }
        }

        private void ProcessProduct(TargetGroup targetGroup, ImportDataFileInput input, Color color, DeliveryTime deliveryTime,Brand brand)
        {
            targetGroup.Articles.Single(a => a.Code == input.ArtikelCode && a.Name == input.ColorCode && a.BrandId == brand.Id).AddProduct(input.Key, new Price(input.Price, input.DiscountPrice),
                               input.Size, color.Id, deliveryTime.Id);
        }

        private async Task<TargetGroup> GetTargetGroup(List<TargetGroup> targetGroups, string targetGroupName)
        {
            var targetGroup = targetGroups.SingleOrDefault(t => t.Name == targetGroupName) ??
                                await _get.Get<TargetGroup>(b => b.Name == targetGroupName);
            ;
            if (targetGroup == null)
            {
                targetGroup = new TargetGroup(targetGroupName);
            }
            return targetGroup;
        }

        private void ProcessArticle(TargetGroup targetGroup, string articleName, string articleCode, Brand brand)
        {
            var article = targetGroup.Articles.SingleOrDefault(a => a.Name == articleName && a.Code == articleCode && a.BrandId == brand.Id);
            if (article == null)
            {
                targetGroup.AddArticle(articleCode, articleName, brand.Id);
            }
            //return article;
        }

        private async Task<Brand> ProcessBrand(string brandName)
        {
            var brand = await _get.Get<Brand>(b => b.Name == brandName);
            if (brand == null)
            {
                brand = new Brand(brandName);
                await _save.Save(brand);
            }
            return brand;
        }

        private async Task<Color> ProcessColor(string colorName)
        {
            var color = await _get.Get<Color>(b => b.Name == colorName);
            if (color == null)
            {
                color = new Color(colorName);
                await _save.Save(color);
            }
            return color;
        }

        private async Task<DeliveryTime> ProcessDeliveryTime(string deliveredIn)
        {
            var deliveredInValues = deliveredIn.Split(' ')[0].Split('-').Select(a => int.Parse(a)).Select(a => TimeSpan.FromDays(a));
            var deliveryTime = await _get.Get<DeliveryTime>(d => d.From == deliveredInValues.ElementAt(0).Ticks && d.To == deliveredInValues.ElementAt(1).Ticks);
            if (deliveryTime == null)
            {
                deliveryTime = new DeliveryTime(deliveredInValues.ElementAt(0), deliveredInValues.ElementAt(1));
                await _save.Save(deliveryTime);
            }
            return deliveryTime;
        }

        //private bool CheckTargetGroupExists(List<TargetGroup> targetGroups, string name)
        //{
        //    return targetGroups.Any(t => t.Name.ToLower() == name.ToLower());
        //}
        //private bool CheckBrandExists(List<Brand> brands, string name)
        //{
        //    return brands.Any(t => t.Name.ToLower() == name.ToLower());
        //}
        //private (bool exists, DeliveryTime deliveryTime) CheckDeliveryTimeExists(List<DeliveryTime> deliveryTimes, string deliveredIn)
        //{
        //    var deliveredInValues = deliveredIn.Split(' ')[0].Split('-').Select(a => int.Parse(a)).Select(a => TimeSpan.FromDays(a));
        //    var exisitngDeliveryTime = deliveryTimes.SingleOrDefault(a => a.From == deliveredInValues.ElementAt(0).Ticks && a.To == deliveredInValues.ElementAt(1).Ticks);
        //    if (exisitngDeliveryTime != null)
        //    {
        //        return (true, exisitngDeliveryTime);
        //    }
        //    else
        //    {
        //        return (false, new DeliveryTime(deliveredInValues.ElementAt(0), deliveredInValues.ElementAt(1)));
        //    }
        //}


    }
}
