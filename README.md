📝 SozlukHub - Mikroservis Tabanlı Sözlük Uygulaması
SozlukHub, kullanıcıların başlıklar (topics) altında entry (girdi) paylaşabildiği, yorum yapabildiği ve oy kullanabildiği modern bir sözlük platformudur. Uygulama mikroservis mimarisiyle inşa edilmiş olup hem backend hem de frontend katmanları ayrıştırılmıştır.


🔧 Kullanılan Teknolojiler
Backend
ASP.NET Core

MassTransit + RabbitMQ (Event-Driven Architecture)

PostgreSQL

Docker

RESTful API

Frontend
React + TypeScript

Vite

Axios

CSS Modules

Authentication
JWT tabanlı kullanıcı doğrulama ve oturum yönetimi


🧩 Mikroservisler

| Servis                | Açıklama                                         |
| --------------------- | ------------------------------------------------ |
| `AuthService`         | Kullanıcı kayıt ve giriş (JWT token üretimi)     |
| `UserService`         | Kullanıcı profili (avatar, bio, username)        |
| `TopicService`        | Başlık (topic) oluşturma ve listeleme            |
| `EntryService`        | Entry oluşturma, listeleme ve detay görüntüleme  |
| `ReviewService`       | Entry'lere yorum ekleme ve yorumları listeleme   |
| `VoteService`         | Beğenme / beğenmeme sistemi                      |
| `NotificationService` | E-mail ile bildirim gönderme (opsiyonel)         |
| `Gateway`             | API Gateway veya doğrudan React üzerinden erişim |


📦 Temel Özellikler
🔐 Kullanıcı Yönetimi
Kayıt ve giriş işlemleri

JWT ile güvenli oturum yönetimi

📚 Başlıklar (Topics)
Tüm başlıkları listeleme

Başlığa tıklayarak ilgili entry'leri görme

✍️ Entry Sistemi
Yeni entry oluşturma

Entry detaylarını görüntüleme

Entry'ye yapılan yorumları görme

Entry’yi beğenme veya beğenmeme

💬 Yorumlar
Entry detayında yorumları listeleme

Giriş yapan kullanıcılar yorum yapabilir

👍 Oylama Sistemi
Her kullanıcı entry başına 1 oy kullanabilir

Beğeni ve beğenmeme sayıları anlık olarak güncellenir

Kim hangi entry’yi beğendi bilgisi gösterilir

🧭 Ana Sayfa
Sol panelde başlıklar

Orta panelde seçilen başlığın entry'leri

Entry'ye tıklayınca detay sayfasına yönlendirme

📷 Ekran Görüntüleri
