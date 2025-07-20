# SecilStoreCase

Bu proje, .NET Core ile geliştirilmiş bir merkezi konfigürasyon yönetim sistemidir.  
Servislerin yapılandırmalarını dinamik olarak yönetebilmesi hedeflenmiştir. MongoDB tabanlı veri saklama, Razor Pages UI, REST API ve timer destekli cache sistemi içerir.

## 🔧 Proje Yapısı

- **configlib** ➜ ConfigReader, Timer, Provider, tip dönüşüm, cache  
- **configdashboard** ➜ UI paneli (Razor Pages) ➜ kayıt ekleme & listeleme  
- **webapi** ➜ REST API ➜ config verisinin dış servislerle paylaşımı  
- **docker-compose.yml** ➜ MongoDB servisinin konteyner üzerinde başlatılması

### 1. Gereksinimler

- .NET  8+
- Ms Visual Studio

Projeyi Docker Üzerinden Başlatma
 ** docker-compose up -d
 
<img width="1276" height="1385" alt="image" src="https://github.com/user-attachments/assets/733f886d-ed40-4f59-8415-7b7e5fdb77f9" />

