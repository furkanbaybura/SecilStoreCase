# SecilStoreCase

Bu proje, .NET Core ile geliştirilmiş bir merkezi konfigürasyon yönetim sistemidir.  
Servislerin yapılandırmalarını dinamik olarak yönetebilmesi hedeflenmiştir. MongoDB tabanlı veri saklama, Razor Pages UI, REST API ve timer destekli cache sistemi içerir.

## 🔧 Proje Yapısı

- **configlib** ➜ ConfigReader, Timer, Provider, tip dönüşüm, concurrency-safe cache  
- **configdashboard** ➜ UI paneli (Razor Pages) ➜ config ekleme & listeleme  
- **webapi** ➜ REST API ➜ config verisinin dış servislerle paylaşımı  
- **test** ➜ Unit test senaryoları (xUnit)  
- **docker-compose.yml** ➜ MongoDB ve RabbitMQ gibi servislerin konteyner üzerinde başlatılması

## 🚀 Kurulum

### 1. Gereksinimler

- .NET SDK 8+
- Visual Studio veya VS Code
