# SecilStoreCase

Bu proje, .NET Core ile geliştirilmiş bir merkezi konfigürasyon yönetim sistemidir.  
Servislerin yapılandırmalarını dinamik olarak yönetebilmesi hedeflenmiştir. MongoDB tabanlı veri saklama, Razor Pages UI, REST API ve timer destekli cache sistemi içerir.

## 🔧 Proje Yapısı

- **configlib** ➜ ConfigReader, Timer, Provider, tip dönüşüm, cache  
- **configdashboard** ➜ UI paneli (Razor Pages) ➜ kayıt ekleme & listeleme  
- **webapi** ➜ REST API ➜ config verisinin dış servislerle paylaşımı  
- **docker-compose.yml** ➜ MongoDB servisinin konteyner üzerinde başlatılması

### 1. Gereksinimler

- .NET SDK 8+
- Visual Studio veya VS Code

Projeyi Docker Üzerinden Başlatma
 ** docker-compose up -d
 
<img width="1271" height="1382" alt="image" src="https://github.com/user-attachments/assets/d0b89a36-afaa-4cba-93eb-63dff6d43f14" />
