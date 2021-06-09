# NorthwindProject

## Getting Started
Çok katlı mimari örneği olan bu proje başlıca Business,DataAccess,Core,Entities ve WebAPI katmanlarından oluşmaktadır.

## Packages
### Business
-Autofac(6.1.0)
-Autofac.Extras.DynamicProxy(6.0.0)
-Autofac.Extensions.DependencyInjection(7.1.0)
-FluentValidation(9.5.1)
-Microsoft.AspNetCore.Http.Abstractions(2.2.0)
-Microsoft.Extensions.DependencyInjection(5.0.1)
-NETStandard.Library(2.0.3)

### Core
-Autofac(6.1.0)
-Autofac.Extensions.DependencyInjection(7.1.0)
-Autofac.Extras.DynamicProxy(6.0.0)
-FluentValidation(9.5.1)
-Microsoft.EntityFrameworkCore.SqlServer(3.1.11)
-Microsoft.AspNetCore.Http(2.2.2)
-Microsoft.AspNetCore.Http.Abstractions(2.2.0)
-Microsoft.AspNetCore.Http.Features(5.0.3)
-Microsoft.Extensions.Configuration(5.0.0)
-Microsoft.IdentityModel.Tokens(6.8.0)
-NETStandard.Library(2.0.3)
-Newtonsoft.Json(12.0.3)
-System.IdentityModel.Tokens.Jwt(6.8.0)

### DataAccess
-Microsoft.EntityFrameworkCore.SqlServer(3.1.11)
-NETStandard.Library(2.0.3)

### WebAPI
-Autofac.Extensions.DependencyInjection(7.1.0)
-Microsoft.AspNetCore.Authentication.JwtBearer(3.1.11)

## Updates
### 1.Gün
-Entities, DataAccess, Business ve Console katmanlarını oluşturuldu.
-Bir Car nesnesi oluşturulup,Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi
-InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonları yazıldı.

### 2.Gün
-Brand ve Color nesneleri eklendi,her iki nesneye de Id ve name özellikleri eklendi.
-Sql Server tarafında yeni bir veritabanı kuruldu,Adı Recap olarak belirlendi ve Cars,Brands,Colors tabloları eklendi.
-Sisteme Generic IEntityRepository altyapısı yazıldı
-Car, Brand ve Color nesneleri için Entity Framework altyapısı yazıldı.

### 3.Gün
-Core katmanı oluşturuldu.
-Tüm sınıflar için crud operasyonları yazıldı.
-IDto oluşturulup gerekli tablolar join edildi.

### 4.Gün
-Core katmanına Result yapılandırması yapıldı.
-Customers ve Users tabloları da oluşturulup birbirleriyle ilişkilendirildi.
-Araba kiralanma bilgilerini tutan Rental tablosu da sisteme eklendi.

### 5.Gün
-Web API katmanı kuruldu.

### 6.Gün
-Projeye Autofac ve FluentValidation desteği eklendi.
-Projeye AOP desteği eklendi.

### 7.Gün
-Api üzerinden arabaya resim ekleyecek sistemi yazıldı. -Resim silme, güncelleme yetenekleri eklendi.

### 8.Gün
-Projeye JWT entegrasyonu yapıldı.

### 9.Gün
-Cache, Transaction ve Performance aspectlerini eklendi.
