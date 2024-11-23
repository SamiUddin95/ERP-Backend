﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Backend.Model;

namespace Backend.Controllers
{
    [ApiController]
    [EnableCors("AllowCors"), Route("[controller]")]
    public class ItemsController : Controller
    {
        ERPContext bMSContext = new ERPContext();

        #region Brand
        [HttpGet]
        [Route("/api/getAllBrands")]
        public IEnumerable<ItemBrand> getAllBrands()
        {
            return bMSContext.ItemBrand.ToList();
        }

        [HttpPost]
        [Route("/api/createBrands")]
        public object createBrands(ItemBrand brand)
        {

            try
            {
                try
                {
                    var brandchk = bMSContext.ItemBrand.SingleOrDefault(u => u.Id == brand.Id);
                    if (brandchk != null)
                    {

                        brandchk.Id = brand.Id;
                        brandchk.Name = brand.Name;
                        brandchk.Remarks = brand.Remarks;
                        brandchk.ManufacturerId = brand.ManufacturerId;
                        brand.UpdatedAt = DateTime.Now;
                        brandchk.UpdatedBy = brand.UpdatedBy;
                        bMSContext.ItemBrand.Update(brandchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = brandchk.Id });
                    }
                    else
                    {
                        ItemBrand brand1 = new ItemBrand();
                        brand1.Name = brand.Name;
                        brand1.Remarks = brand.Remarks;
                        brand1.ManufacturerId = brand.ManufacturerId;
                        brand1.CreatedAt = DateTime.Now;
                        brand1.CreatedBy = brand.CreatedBy;
                        bMSContext.ItemBrand.Add(brand1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = brand1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("/api/deleteBrandById")]
        public object deleteBrandById(int id)
        {
            try
            {
                var delbrand = bMSContext.ItemBrand.SingleOrDefault(u => u.Id == id);
                if (delbrand != null)
                {
                    bMSContext.ItemBrand.Remove(delbrand);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delbrand.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getBrandById")]
        public IEnumerable<ItemBrand> getBrandById(int id)
        {
            return bMSContext.ItemBrand.Where(u => u.Id == id).ToList();
        }
        #endregion

        #region Category

        [HttpGet]
        [Route("/api/getAllCategory")]
        public IEnumerable<ItemCategory> getAllCategory()
        {
            return bMSContext.ItemCategory.ToList();
        }

        [HttpPost]
        [Route("/api/createCategory")]
        public object createCategory(ItemCategory itemCategory)
        {

            try
            {
                try
                {
                    var categorychk = bMSContext.ItemCategory.SingleOrDefault(u => u.Id == itemCategory.Id);
                    if (categorychk != null)
                    {

                        categorychk.Id = itemCategory.Id;
                        categorychk.Name = itemCategory.Name;
                        categorychk.IsActive = itemCategory.IsActive;
                        categorychk.Priority = itemCategory.Priority;
                        //categorychk.DepartmentId = itemCategory.DepartmentId;
                        categorychk.DepartmentId = 1;
                        categorychk.Height = itemCategory.Height;
                        categorychk.Width = itemCategory.Width;
                        categorychk.Description = itemCategory.Description;
                        categorychk.UpdatedAt = DateTime.Now;
                        categorychk.UpdatedBy = itemCategory.UpdatedBy;
                        bMSContext.ItemCategory.Update(categorychk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = categorychk.Id });
                    }
                    else
                    {
                        ItemCategory itemCategory1 = new ItemCategory();
                        //brandchk.Id = brand.Id;
                        itemCategory1.Name = itemCategory.Name;
                        itemCategory1.IsActive = itemCategory.IsActive;
                        itemCategory1.Priority = itemCategory.Priority;
                        //itemCategory1.DepartmentId = itemCategory.DepartmentId;
                        itemCategory1.DepartmentId = 1;
                        itemCategory1.Height = itemCategory.Height;
                        itemCategory1.Width = itemCategory.Width;
                        itemCategory1.Description = itemCategory.Description;
                        itemCategory1.CreatedAt = DateTime.Now;
                        itemCategory1.CreatedBy = itemCategory.CreatedBy;
                        bMSContext.ItemCategory.Add(itemCategory1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemCategory1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("/api/deleteCategoryById")]
        public object deleteCatgoryById(int id)
        {
            try
            {
                var delcategory = bMSContext.ItemCategory.SingleOrDefault(u => u.Id == id);
                if (delcategory != null)
                {
                    bMSContext.ItemCategory.Remove(delcategory);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delcategory.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getCategoryById")]
        public IEnumerable<ItemCategory> getCategoryById(int id)
        {
            return bMSContext.ItemCategory.Where(u => u.Id == id).ToList();
        }

        #endregion

        #region Class

        [HttpGet]
        [Route("/api/getAllClass")]
        public IEnumerable<ItemClass> getAllClass()
        {
            return bMSContext.ItemClass.ToList();
        }

        [HttpPost]
        [Route("/api/createClass")]
        public object createClass(ItemClass itemClass)
        {

            try
            {
                try
                {
                    var classchk = bMSContext.ItemClass.SingleOrDefault(u => u.Id == itemClass.Id);
                    if (classchk != null)
                    {

                        classchk.Id = itemClass.Id;
                        classchk.Name = itemClass.Name;
                        classchk.DepartmentId = itemClass.DepartmentId;
                        classchk.CategoryId = itemClass.CategoryId;
                        classchk.UpdatedAt = DateTime.Now;
                        classchk.UpdatedBy = itemClass.UpdatedBy;
                        bMSContext.ItemClass.Update(classchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = classchk.Id });
                    }
                    else
                    {
                        ItemClass itemClass1 = new ItemClass();

                        itemClass1.Name = itemClass.Name;
                        itemClass1.DepartmentId = itemClass.DepartmentId;
                        itemClass1.CategoryId = itemClass.CategoryId;
                        itemClass1.CreatedAt = DateTime.Now;
                        itemClass1.CreatedBy = itemClass.CreatedBy;
                        bMSContext.ItemClass.Add(itemClass1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemClass1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("/api/deleteClassById")]
        public object deleteClassById(int id)
        {
            try
            {
                var delclass = bMSContext.ItemClass.SingleOrDefault(u => u.Id == id);
                if (delclass != null)
                {
                    bMSContext.ItemClass.Remove(delclass);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delclass.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getClassById")]
        public IEnumerable<ItemClass> getClassById(int id)
        {
            return bMSContext.ItemClass.Where(u => u.Id == id).ToList();
        }
        #endregion

        #region Item

        [HttpGet]
        [Route("/api/getAllItems")]
        public IEnumerable<Item> getAllItems()
        {
            return bMSContext.Item.ToList();
        }


        [HttpGet]
        [Route("/api/getAllItemsdetailsFilterbased")]
        public IEnumerable<Item> getAllItemsdetailsFilterbased(string itemName, string aliasName, decimal purchasePrice, decimal salePrice)
        {
            var query = bMSContext.Item.AsQueryable();
            if (itemName != "All")
            {
                query = query.Where(i => i.ItemName.Contains(itemName));
            }

            if (aliasName != "All")
            {
                query = query.Where(i => i.AliasName.Contains(aliasName));
            }
            if (purchasePrice > 0)
            {
                query = query.Where(i => i.PurchasePrice == purchasePrice);
            }

            if (salePrice > 0)
            {
                query = query.Where(i => i.SalePrice == salePrice);
            }

            return query.ToList();
        }

        [HttpGet]
        [Route("/api/getAllBrandsdetailsFilterbased")]
        public IEnumerable<ItemBrand> getAllBrandsdetailsFilterbased(string brandName)
        {
            var query = bMSContext.ItemBrand.AsQueryable();
            if (brandName != "All")
            {
                query = query.Where(i => i.Name.Contains(brandName));
            }

            return query.ToList();
        }

        [HttpGet]
        [Route("/api/getAllCategorydetailsFilterbased")]
        public IEnumerable<ItemCategory> getAllCategorydetailsFilterbased(string Name, string description)
        {
            var query = bMSContext.ItemCategory.AsQueryable();
            if (Name != "All")
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            if (description != "All")
            {
                query = query.Where(i => i.Description.Contains(description));
            }

            return query.ToList();
        }
        [HttpGet]
        [Route("/api/getAllClassdetailsFilterbased")]
        public IEnumerable<ItemClass> getAllClassdetailsFilterbased(string className)
        {
            var query = bMSContext.ItemClass.AsQueryable();
            if (className != "All")
            {
                query = query.Where(i => i.Name.Contains(className));
            }

            return query.ToList();
        }

        [HttpGet]
        [Route("/api/getAllManufacturedetailsFilterbased")]
        public IEnumerable<ItemManufacturer> getAllManufacturedetailsFilterbased(string name, string email)
        {
            var query = bMSContext.ItemManufacturer.AsQueryable();
            if (name != "All")
            {
                query = query.Where(i => i.Name.Contains(name));
            }
            if (email != "All")
            {
                query = query.Where(i => i.Email.Contains(email));
            }
            return query.ToList();
        }

        [HttpPost]
        [Route("/api/createItems")]
        public object createItems(ItemModel Items)
        {
            try
            {
                var existingItem = bMSContext.Item.SingleOrDefault(i => i.ItemName == Items.ItemName && i.Id != Items.Id);
                if (existingItem != null)
                {
                    return JsonConvert.SerializeObject(new { msg = "An item with this name already exists." });
                }

                var Itemschk = bMSContext.Item.SingleOrDefault(u => u.Id == Items.Id);
                if (Itemschk != null)
                {
                    // Update existing item
                    Itemschk.AliasName = Items.AliasName;
                    Itemschk.ItemName = Items.ItemName;
                    Itemschk.PurchasePrice = Items.PurchasePrice;
                    Itemschk.SalePrice = Items.SalePrice;
                    Itemschk.CategoryId = Items.CategoryId;
                    Itemschk.ClassId = Items.ClassId;
                    Itemschk.ManufacturerId = Items.ManufacturerId;
                    Itemschk.Remarks = Items.Remarks;
                    Itemschk.RecentPurchase = Items.RecentPurchase;
                    Itemschk.BrandId = Items.BrandId;
                    Itemschk.Discflat = Items.Discflat;
                    Itemschk.Lockdisc = Items.Lockdisc;
                    Itemschk.UpdatedAt = DateTime.Now;
                    Itemschk.UpdatedBy = Items.UpdatedBy;
                    bMSContext.Item.Update(Itemschk);
                    bMSContext.SaveChanges();

                    var delAltItem = bMSContext.AlternateItem.Where(u => u.ItemId == Items.Id).ToList();
                    if (delAltItem.Any())
                    {
                        bMSContext.AlternateItem.RemoveRange(delAltItem);
                        bMSContext.SaveChanges();
                    }

                    foreach (var item in Items.alternateItem)
                    {
                        AlternateItem at = new AlternateItem
                        {
                            AliasName = item.AliasName,
                            Salediscflat = item.Salediscflat,
                            Salediscperc = item.Salediscperc,
                            ItemId = Items.Id,
                            Remarks = item.Remarks,
                            Qty = item.Qty
                        };
                        bMSContext.AlternateItem.Add(at);
                    }
                    bMSContext.SaveChanges();

                    return JsonConvert.SerializeObject(new { id = Itemschk.Id });
                }
                else
                {
                    // Add new item
                    Item itemItems = new Item
                    {
                        AliasName = Items.AliasName,
                        ItemName = Items.ItemName,
                        PurchasePrice = Items.PurchasePrice,
                        SalePrice = Items.SalePrice,
                        CategoryId = Items.CategoryId,
                        Lockdisc = Items.Lockdisc,
                        ClassId = Items.ClassId,
                        ManufacturerId = Items.ManufacturerId,
                        Remarks = Items.Remarks,
                        RecentPurchase = Items.RecentPurchase,
                        BrandId = Items.BrandId,
                        Discflat = Items.Discflat,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Items.CreatedBy
                    };
                    bMSContext.Item.Add(itemItems);
                    bMSContext.SaveChanges();

                    foreach (var item in Items.alternateItem)
                    {
                        AlternateItem at = new AlternateItem
                        {
                            AliasName = item.AliasName,
                            Salediscflat = item.Salediscflat,
                            Salediscperc = item.Salediscperc,
                            ItemId = itemItems.Id,
                            Remarks = item.Remarks,
                            Qty = item.Qty
                        };
                        bMSContext.AlternateItem.Add(at);
                    }
                    bMSContext.SaveChanges();

                    return JsonConvert.SerializeObject(new { id = itemItems.Id });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("/api/createChildParentItem")]
        public object createChildParentItem(ParentChildModel parentChildModel)
        {
            try
            {
                try
                {
                    var parentchk = bMSContext.ParentItem.SingleOrDefault(u => u.Id == parentChildModel.Id);
                    if (parentchk != null)
                    {
                        parentchk.Barcode = parentChildModel.Barcode;
                        parentchk.ParentName = parentChildModel.ParentName;
                        parentchk.Uom = parentChildModel.Uom;
                        parentchk.Weight = parentChildModel.Weight;
                        parentchk.NetCost = parentChildModel.NetCost;
                        parentchk.SalePrice = parentChildModel.SalePrice;
                        parentchk.DiscPerc = parentChildModel.DiscPerc;
                        parentchk.DiscValue = parentChildModel.DiscValue;
                        parentchk.Misc = parentChildModel.Misc;
                        parentchk.NetSalePrice = parentChildModel.NetSalePrice;
                        parentchk.ManualSalePrice = parentChildModel.ManualSalePrice;
                        parentchk.Profit = parentChildModel.Profit;
                        parentchk.UpdatedAt = DateTime.Now;
                        parentchk.UpdatedBy = parentChildModel.UpdatedBy;
                        bMSContext.ParentItem.Update(parentchk);
                        bMSContext.SaveChanges();

                        var delChlItem = bMSContext.ChildItem.Where(u => u.ParentItemId == parentChildModel.Id).ToList();
                        if (delChlItem.Any())
                        {
                            bMSContext.ChildItem.RemoveRange(delChlItem);
                            bMSContext.SaveChanges();
                        }
                        foreach (var childitem in parentChildModel.childItem)
                        {
                            ChildItem at = new ChildItem
                            {
                                ParentItemId = parentChildModel.Id,
                                Barcode = childitem.Barcode,
                                ChildName = childitem.ChildName,
                                Uom = childitem.Uom,
                                Weight = childitem.Weight,
                                NetCost = childitem.NetCost,
                                SalePrice = childitem.SalePrice,
                                DiscPerc = childitem.DiscPerc,
                                DiscValue = childitem.DiscValue,
                                Misc = childitem.Misc,
                                NetSalePrice = childitem.NetSalePrice,
                                ManualSalePrice = childitem.ManualSalePrice,
                                Profit = childitem.Profit,
                                UpdatedAt = DateTime.Now,
                                UpdatedBy = childitem.UpdatedBy
                            };
                            bMSContext.ChildItem.Update(at);
                        }
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = parentchk.Id });
                    }
                    else
                    {
                        var getItemId = 0;
                        if (parentChildModel.ParentName != null)
                        {
                            getItemId = bMSContext.Item.Where(x => x.ItemName == parentChildModel.ParentName).FirstOrDefault().Id;
                        }
                        ParentItem parentItem1 = new ParentItem();
                        parentItem1.ItemId = getItemId;
                        parentItem1.Barcode = parentChildModel.Barcode;
                        parentItem1.ParentName = parentChildModel.ParentName;
                        parentItem1.Uom = parentChildModel.Uom;
                        parentItem1.Weight = parentChildModel.Weight;
                        parentItem1.NetCost = parentChildModel.NetCost;
                        parentItem1.SalePrice = parentChildModel.SalePrice;
                        parentItem1.DiscPerc = parentChildModel.DiscPerc;
                        parentItem1.DiscValue = parentChildModel.DiscValue;
                        parentItem1.Misc = parentChildModel.Misc;
                        parentItem1.NetSalePrice = parentChildModel.NetSalePrice;
                        parentItem1.ManualSalePrice = parentChildModel.ManualSalePrice;
                        parentItem1.Profit = parentChildModel.Profit;
                        parentItem1.CreatedAt = DateTime.Now;
                        parentItem1.CreatedBy = parentChildModel.CreatedBy;
                        bMSContext.ParentItem.Add(parentItem1);
                        bMSContext.SaveChanges();

                        foreach (var childitem in parentChildModel.childItem)
                        {
                            ChildItem at = new ChildItem
                            {
                                ParentItemId = parentItem1.Id,
                                Barcode = childitem.Barcode,
                                ChildName = childitem.ChildName,
                                Uom = childitem.Uom,
                                Weight = childitem.Weight,
                                NetCost = childitem.NetCost,
                                SalePrice = childitem.SalePrice,
                                DiscPerc = childitem.DiscPerc,
                                DiscValue = childitem.DiscValue,
                                Misc = childitem.Misc,
                                NetSalePrice = childitem.NetSalePrice,
                                ManualSalePrice = childitem.ManualSalePrice,
                                Profit = childitem.Profit,
                                CreatedAt = DateTime.Now,
                                CreatedBy = childitem.CreatedBy
                            };
                            bMSContext.ChildItem.Add(at);
                        }
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = parentItem1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }
        //[HttpPost]
        //[Route("/api/createItems")]
        //public object createItems(ItemModel Items)
        //{
        //    try
        //    {
        //        var existingItem = bMSContext.Item.SingleOrDefault(i => i.ItemName == Items.ItemName && i.Id != Items.Id);
        //        if (existingItem != null)
        //        {
        //            var Itemschk = bMSContext.Item.SingleOrDefault(u => u.Id == Items.Id);
        //            if (Itemschk != null)
        //            {

        //                Itemschk.Id = Items.Id;
        //                Itemschk.AliasName = Items.AliasName;
        //                Itemschk.ItemName = Items.ItemName;
        //                Itemschk.PurchasePrice = Items.PurchasePrice;
        //                Itemschk.SalePrice = Items.SalePrice;
        //                Itemschk.CategoryId = Items.CategoryId;
        //                Itemschk.ClassId = Items.ClassId;
        //                Itemschk.ManufacturerId = Items.ManufacturerId;
        //                Itemschk.Remarks = Items.Remarks;
        //                Itemschk.RecentPurchase = Items.RecentPurchase;
        //                Itemschk.BrandId = Items.BrandId;
        //                Itemschk.Discflat = Items.Discflat;
        //                Itemschk.Lockdisc = Items.Lockdisc;
        //                Itemschk.UpdatedAt = DateTime.Now;
        //                Itemschk.UpdatedBy = Items.UpdatedBy;
        //                bMSContext.Item.Update(Itemschk);
        //                bMSContext.SaveChanges();
        //                var delAltItem = bMSContext.AlternateItem.SingleOrDefault(u => u.ItemId == Items.Id);
        //                if (delAltItem != null)
        //                {
        //                    bMSContext.AlternateItem.Remove(delAltItem);
        //                    bMSContext.SaveChanges();
        //                }
        //                foreach (var item in Items.alternateItem)
        //                {
        //                    if (item.AliasName != "")
        //                    {
        //                        AlternateItem at = new AlternateItem();
        //                        at.AliasName = item.AliasName;
        //                        at.Salediscflat = item.Salediscflat;
        //                        at.Salediscperc = item.Salediscperc;
        //                        at.ItemId = item.Id;
        //                        at.Remarks = item.Remarks;
        //                        at.Qty = item.Qty;
        //                        bMSContext.AlternateItem.Add(at);
        //                        bMSContext.SaveChanges();
        //                    }

        //                }
        //                return JsonConvert.SerializeObject(new { id = Itemschk.Id });
        //            }
        //            else
        //            {
        //                var existingItem = bMSContext.Item.SingleOrDefault(i => i.ItemName == Items.ItemName);

        //                if (existingItem != null)
        //                {
        //                    return JsonConvert.SerializeObject(new { msg = "An item with this name already exists." });
        //                }
        //                Item itemItems = new Item();
        //                itemItems.AliasName = Items.AliasName;
        //                itemItems.ItemName = Items.ItemName;
        //                itemItems.PurchasePrice = Items.PurchasePrice;
        //                itemItems.SalePrice = Items.SalePrice;
        //                itemItems.CategoryId = Items.CategoryId;
        //                itemItems.ClassId = Items.ClassId;
        //                itemItems.ManufacturerId = Items.ManufacturerId;
        //                itemItems.Remarks = Items.Remarks;
        //                itemItems.RecentPurchase = Items.RecentPurchase;
        //                itemItems.BrandId = Items.BrandId;
        //                itemItems.Discflat = Items.Discflat;
        //                itemItems.Lockdisc = Items.Lockdisc;
        //                itemItems.CreatedAt = DateTime.Now;
        //                itemItems.CreatedBy = Items.CreatedBy;
        //                bMSContext.Item.Add(itemItems);
        //                bMSContext.SaveChanges();
        //                foreach (var item in Items.alternateItem)
        //                {
        //                    if (item.AliasName != "")
        //                    {
        //                        AlternateItem at = new AlternateItem();
        //                        at.AliasName = item.AliasName;
        //                        at.Salediscflat = item.Salediscflat;
        //                        at.Salediscperc = item.Salediscperc;
        //                        at.ItemId = itemItems.Id;
        //                        at.Remarks = item.Remarks;
        //                        at.Qty = item.Qty;
        //                        bMSContext.AlternateItem.Add(at);
        //                        bMSContext.SaveChanges();
        //                    }

        //                }
        //                return JsonConvert.SerializeObject(new { id = itemItems.Id });
        //            }
        //            //return JsonConvert.SerializeObject(new { msg = "An item with this name already exists." });
        //        }

        //        var Itemschk = bMSContext.Item.SingleOrDefault(u => u.Id == Items.Id);
        //        if (Itemschk != null)
        //        {
        //            // Update existing item
        //            Itemschk.AliasName = Items.AliasName;
        //            Itemschk.ItemName = Items.ItemName;
        //            Itemschk.PurchasePrice = Items.PurchasePrice;
        //            Itemschk.SalePrice = Items.SalePrice;
        //            Itemschk.CategoryId = Items.CategoryId;
        //            Itemschk.ClassId = Items.ClassId;
        //            Itemschk.ManufacturerId = Items.ManufacturerId;
        //            Itemschk.Remarks = Items.Remarks;
        //            Itemschk.RecentPurchase = Items.RecentPurchase;
        //            Itemschk.BrandId = Items.BrandId;
        //            Itemschk.Discflat = Items.Discflat;
        //            Itemschk.Lockdisc = Items.Lockdisc;
        //            Itemschk.UpdatedAt = DateTime.Now;
        //            Itemschk.UpdatedBy = Items.UpdatedBy;
        //            bMSContext.Item.Update(Itemschk);
        //            bMSContext.SaveChanges();

        //            var delAltItem = bMSContext.AlternateItem.Where(u => u.ItemId == Items.Id).ToList();
        //            if (delAltItem.Any())
        //            {
        //                bMSContext.AlternateItem.RemoveRange(delAltItem);
        //                bMSContext.SaveChanges();
        //            }

        //            foreach (var item in Items.alternateItem)
        //            {
        //                AlternateItem at = new AlternateItem
        //                {
        //                    AliasName = item.AliasName,
        //                    Salediscflat = item.Salediscflat,
        //                    Salediscperc = item.Salediscperc,
        //                    ItemId = Items.Id,
        //                    Remarks = item.Remarks,
        //                    Qty = item.Qty
        //                };
        //                bMSContext.AlternateItem.Add(at);
        //            }
        //            bMSContext.SaveChanges();

        //            return JsonConvert.SerializeObject(new { id = Itemschk.Id });
        //        }
        //        else
        //        {
        //            // Add new item
        //            Item itemItems = new Item
        //            {
        //                AliasName = Items.AliasName,
        //                ItemName = Items.ItemName,
        //                PurchasePrice = Items.PurchasePrice,
        //                SalePrice = Items.SalePrice,
        //                CategoryId = Items.CategoryId,
        //                Lockdisc = Items.Lockdisc,
        //                ClassId = Items.ClassId,
        //                ManufacturerId = Items.ManufacturerId,
        //                Remarks = Items.Remarks,
        //                RecentPurchase = Items.RecentPurchase,
        //                BrandId = Items.BrandId,
        //                Discflat = Items.Discflat,
        //                CreatedAt = DateTime.Now,
        //                CreatedBy = Items.CreatedBy
        //            };
        //            bMSContext.Item.Add(itemItems);
        //            bMSContext.SaveChanges();

        //            foreach (var item in Items.alternateItem)
        //            {
        //                AlternateItem at = new AlternateItem
        //                {
        //                    AliasName = item.AliasName,
        //                    Salediscflat = item.Salediscflat,
        //                    Salediscperc = item.Salediscperc,
        //                    ItemId = itemItems.Id,
        //                    Remarks = item.Remarks,
        //                    Qty = item.Qty
        //                };
        //                bMSContext.AlternateItem.Add(at);
        //            }
        //            bMSContext.SaveChanges();

        //            return JsonConvert.SerializeObject(new { id = itemItems.Id });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return JsonConvert.SerializeObject(new { msg = ex.Message });
        //    }
        //}


        [HttpGet]
        [Route("/api/deleteItemById")]
        public object deleteItemById(int id)
        {
            try
            {
                var delitem = bMSContext.Item.SingleOrDefault(u => u.Id == id);
                if (delitem != null)
                {
                    bMSContext.Item.Remove(delitem);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delitem.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getItemById")]
        public IEnumerable<dynamic> getItemById(int id)
        {

            var item = bMSContext.Item.Select(it => new
            {
                id = it.Id,
                aliasName = it.AliasName,
                brandId = it.BrandId,
                manufacturerId = it.ManufacturerId,
                salePrice = it.SalePrice,
                remarks = it.Remarks,
                itemName = it.ItemName,
                categoryId = it.CategoryId,
                classId = it.ClassId,
                purchasePrice = it.PurchasePrice,
                recentPurchase = it.RecentPurchase,
                discflat = it.Discflat,
                lockdisc = it.Lockdisc

            }).Where(u => u.id == id).ToList();
            var altItem = bMSContext.AlternateItem
                .Select(alt => new
                {
                    id = alt.Id,
                    itemId = alt.ItemId,
                    aliasName = alt.AliasName,
                    qty = alt.Qty,
                    saleDiscPerc = alt.Salediscperc,
                    saleDiscFlat = alt.Salediscflat,
                    remarks = alt.Remarks,
                }).Where(x => x.itemId == id).ToList();
            var parentItem = bMSContext.ParentItem
                .Select(parent => new
                {
                    id = parent.Id,
                    itemId = parent.ItemId,
                    barcode = parent.Barcode,
                    parentName = parent.ParentName,
                    uom = parent.Uom,
                    weight = parent.Weight,
                    netCost = parent.NetCost,
                    salePrice = parent.SalePrice,
                    discPerc = parent.DiscPerc,
                    discValue = parent.DiscValue,
                    misc = parent.Misc,
                    netSalePrice = parent.NetSalePrice,
                    profit = parent.Profit,
                    manualSalePrice = parent.ManualSalePrice,
                }).Where(x=>x.itemId == id).ToList();

            if (parentItem.Count > 0)
            {
                var childItem = bMSContext.ChildItem
                .Select(parent => new
                {
                    id = parent.Id,
                    parentId = parent.ParentItemId,
                    barcode = parent.Barcode,
                    childName = parent.ChildName,
                    uom = parent.Uom,
                    weight = parent.Weight,
                    netCost = parent.NetCost,
                    salePrice = parent.SalePrice,
                    discPerc = parent.DiscPerc,
                    discValue = parent.DiscValue,
                    misc = parent.Misc,
                    netSalePrice = parent.NetSalePrice,
                    profit = parent.Profit,
                    manualSalePrice = parent.ManualSalePrice,
                }).Where(x => x.parentId == parentItem[0].id).ToList();

                var result = new
                {
                    item = item,
                    altItem = altItem,
                    parentItem = parentItem,
                    childItem = childItem
                };
                yield return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new
                {
                    item = item,
                    altItem = altItem,
                    parentItem = parentItem
                };
                yield return JsonConvert.SerializeObject(result);
            }
         

           
        }
        #endregion

        #region Manufacturer

        [HttpGet]
        [Route("/api/getAllManufacturer")]
        public IEnumerable<ItemManufacturer> getAllManufacturer()
        {
            return bMSContext.ItemManufacturer.ToList();
        }

        [HttpPost]
        [Route("/api/createManufacturer")]
        public object createManufacturer(ItemManufacturer itemManufacturer)
        {

            try
            {
                try
                {
                    var Manufacturerchk = bMSContext.ItemManufacturer.SingleOrDefault(u => u.Id == itemManufacturer.Id);
                    if (Manufacturerchk != null)
                    {

                        Manufacturerchk.Id = itemManufacturer.Id;
                        Manufacturerchk.Name = itemManufacturer.Name;
                        Manufacturerchk.Telephoneno = itemManufacturer.Telephoneno;
                        Manufacturerchk.Telephoneno2 = itemManufacturer.Telephoneno2;
                        Manufacturerchk.Email = itemManufacturer.Email;
                        Manufacturerchk.Address = itemManufacturer.Address;
                        Manufacturerchk.UpdatedAt = DateTime.Now;
                        Manufacturerchk.UpdatedBy = itemManufacturer.UpdatedBy;
                        bMSContext.ItemManufacturer.Update(Manufacturerchk);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = Manufacturerchk.Id });
                    }
                    else
                    {
                        ItemManufacturer itemManufacturer1 = new ItemManufacturer();

                        itemManufacturer1.Name = itemManufacturer.Name;
                        itemManufacturer1.Telephoneno = itemManufacturer.Telephoneno;
                        itemManufacturer1.Telephoneno2 = itemManufacturer.Telephoneno2;
                        itemManufacturer1.Email = itemManufacturer.Email;
                        itemManufacturer.Address = itemManufacturer.Address;
                        itemManufacturer.CreatedAt = DateTime.Now;
                        itemManufacturer.CreatedBy = itemManufacturer.CreatedBy;
                        bMSContext.ItemManufacturer.Add(itemManufacturer1);
                        bMSContext.SaveChanges();
                        return JsonConvert.SerializeObject(new { id = itemManufacturer1.Id });
                    }
                }

                catch (Exception ex)
                {
                    JsonConvert.SerializeObject(new { msg = ex.Message });
                }
                return JsonConvert.SerializeObject(new { msg = "Message" });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("/api/deleteManufacturerById")]
        public object deleteManufacturerById(int id)
        {
            try
            {
                var delmanufacturer = bMSContext.ItemManufacturer.SingleOrDefault(u => u.Id == id);
                if (delmanufacturer != null)
                {
                    bMSContext.ItemManufacturer.Remove(delmanufacturer);
                    bMSContext.SaveChanges();
                    return JsonConvert.SerializeObject(new { id = delmanufacturer.Id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        [HttpGet]
        [Route("/api/getManufacturerById")]
        public IEnumerable<ItemManufacturer> getManufacturerById(int id)
        {
            return bMSContext.ItemManufacturer.Where(u => u.Id == id).ToList();
        }
        #endregion

        [HttpGet]
        [Route("/api/getDepartment")]
        public IEnumerable<Department> getDepartment()
        {
            return bMSContext.Department.ToList();
        }

        [HttpGet]
        [Route("/api/getActive")]
        public IEnumerable<Active> getActive()
        {
            return bMSContext.Active.ToList();
        }
    }
}
