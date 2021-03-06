﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintrnanceTime = "Bakım zamanı";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategori de en fazla 10 ürün olabilir.";
        public static string CategoryLimitExceded = "Kategori sayısı 15 olabilir.";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductNameAlreadyExists = "Ürün ismi aynı olamaz!";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered= "Kullanıcı Kayıt Başarılı!";
        public static string UserNotFound="Kullanıcı Bulunamadı!";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullıcı Mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}
