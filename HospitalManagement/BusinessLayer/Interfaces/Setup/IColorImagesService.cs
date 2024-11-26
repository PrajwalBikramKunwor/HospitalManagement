﻿using System.Collections.Generic;
using HospitalManagement.BusinessLayer.DTO;
using HospitalManagement.Models;

namespace HospitalManagement.BusinessLayer.Interface
{
    public interface IColorImagesService
    {
        List<ColorImagesDTO> GetAllColorImages();
        List<ColorImagesDTO> GetAllColorImagesListByStockId(int stockId);
        string GetValueByName(string ColorImagesName);
        ColorImagesDTO GetColorImagesById(string ColorImagesName);
        bool DeleteColorImages(int mnId);
        ColorImagesDTO GetColorImagesByIdd(int MnId);
        int CreateColorImages(ColorImagesDTO ColorImagesUI);
        Task<List<ColorImagesDTO>> CreateColorImagesList(List<ColorImagesDTO> ColorImagesList, int StockId);
    }
}