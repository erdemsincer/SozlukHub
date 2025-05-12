# 📝 SozlukHub - Mikroservis Tabanlı Sözlük Uygulaması

**SozlukHub**, kullanıcıların başlıklar (_topics_) altında entry (_girdi_) paylaşabildiği, yorum yapabildiği ve oy kullanabildiği modern bir sözlük platformudur. Uygulama **mikroservis mimarisi** ile geliştirilmiş olup hem **backend** hem de **frontend** katmanları ayrıştırılmıştır.

---

## 🔧 Kullanılan Teknolojiler

### Backend

- ASP.NET Core
- MassTransit + RabbitMQ (Event-Driven Architecture)
- PostgreSQL
- Docker
- RESTful API

### Frontend

- React + TypeScript
- Vite
- Axios
- CSS Modules

### Authentication

- JWT tabanlı kullanıcı doğrulama ve oturum yönetimi

---

## 🧩 Mikroservisler

| Servis                | Açıklama                                          |
|-----------------------|---------------------------------------------------|
| `AuthService`         | Kullanıcı kayıt ve giriş (JWT token üretimi)     |
| `UserService`         | Kullanıcı profili (avatar, bio, username)        |
| `TopicService`        | Başlık (topic) oluşturma ve listeleme            |
| `EntryService`        | Entry oluşturma, listeleme ve detay görüntüleme  |
| `ReviewService`       | Entry'lere yorum ekleme ve yorumları listeleme   |
| `VoteService`         | Beğenme / beğenmeme sistemi                      |
| `NotificationService` | E-mail ile bildirim gönderme (opsiyonel)         |
| `Gateway`             | API Gateway veya doğrudan React üzerinden erişim |

---

## 📦 Temel Özellikler

### 🔐 Kullanıcı Yönetimi
- Kayıt ve giriş işlemleri
- JWT ile güvenli oturum yönetimi

### 📚 Başlıklar (Topics)
- Tüm başlıkları listeleme
- Başlığa tıklayarak ilgili entry'leri görme

### ✍️ Entry Sistemi
- Yeni entry oluşturma
- Entry detaylarını görüntüleme
- Entry'ye yapılan yorumları görme
- Entry’yi beğenme veya beğenmeme

### 💬 Yorumlar
- Entry detayında yorumları listeleme
- Giriş yapan kullanıcılar yorum yapabilir

### 👍 Oylama Sistemi
- Her kullanıcı entry başına 1 oy kullanabilir
- Beğeni ve beğenmeme sayıları anlık olarak güncellenir
- Kim hangi entry’yi beğendi bilgisi gösterilir

### 🧭 Ana Sayfa
- Sol panelde başlıklar
- Orta panelde seçilen başlığın entry'leri
- Entry'ye tıklayınca detay sayfasına yönlendirme

---

## 📷 Ekran Görüntüleri

![Image](https://github.com/user-attachments/assets/04445e66-0ed5-4154-ac63-04c090f9348d)

![Image](https://github.com/user-attachments/assets/ab3726b5-9dd8-41e5-a87f-6eb2117206fb)

![Image](https://github.com/user-attachments/assets/0ed8fb41-27ef-4290-8fa4-5849bd9327fd)

![Image](https://github.com/user-attachments/assets/6fcb5600-7c91-4972-9cd7-58c2591edb8b)

![Image](https://github.com/user-attachments/assets/65794819-bdbe-43e3-86e4-f8d0ce3c6d60)

![Image](https://github.com/user-attachments/assets/9b64df3e-9e95-4c82-b208-6d1a9f76e45b)

![Image](https://github.com/user-attachments/assets/252d4164-e432-4047-ad5e-5d8bc2d6053d)
