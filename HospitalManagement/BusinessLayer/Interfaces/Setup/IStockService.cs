﻿using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.Models;
namespace HospitalManagement.BusinessLayer.Interface;

public interface IStockService
{
    List<StockDTO> GetAllStock();
    List<StockDTO> GetAllStockBYFilter(int IsActive);
    StockDTO GetStockById(int stId);
    StockDTO GetStockByBarcodeId(int? barcodeId);
    int CreateStock(StockDTO stockUI);
    bool DeleteStock(int stId);
    StockDTO GetAllKindOfStock();
    List<StockDTO> GetLatestDetail(string FromDate, string ToDate);
    List<StockMenuView> GetStockMenuList(string search);
}