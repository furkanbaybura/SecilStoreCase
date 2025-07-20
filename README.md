# SecilStoreCase

Bu proje, .NET Core tabanlı bir merkezi konfigürasyon yönetim sistemi sunar.  
Konfigürasyon verileri MongoDB üzerinde saklanır ve servisler tarafından `ConfigReader` üzerinden dinamik olarak okunur.  
Dashboard UI ile kayıtlar yönetilebilir, Web API üzerinden dış sistemlere sunulabilir.

## 🧱 Modül Yapısı

- **configlib** ➜ ConfigReader, provider, tip dönüşüm, cache ve timer sistemi  
- **configdashboard** ➜ Razor Pages UI ➜ listeleme, ekleme, canlı panel  
- **webapi** ➜ REST API ➜ dış servisler için veri paylaşımı  
- **test** ➜ xUnit ile unit test senaryoları

## 🚀 Kurulum

```bash
docker-compose up -d
