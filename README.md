# 🚗 Araç Kiralama Otomasyonu

Bu proje, C# (Windows Forms) ve SQL Server kullanılarak geliştirilmiş basit bir **Araç Kiralama Otomasyonu**dur. Proje, kullanıcıların araç kiralayabildiği, araç listesini görüntüleyebildiği ve veritabanı üzerinde temel CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirebildiği bir yapıya sahiptir.

## 🚀 Özellikler

- 🚘 Araç listesi görüntüleme  
- ➕ Yeni araç ekleme  
- ✏️ Araç bilgilerini güncelleme ve silme  
- 👤 Müşteri kayıt işlemleri  
- 📅 Araç kiralama ve teslim işlemleri  
- 🔌 SQL Server ile bağlantı

## 🛠️ Kullanılan Teknolojiler

- **C# (Windows Forms)**
- **.NET Framework**
- **SQL Server**
- **ADO.NET** (SqlConnection, SqlCommand vs.)

## 🔧 Veritabanı Bağlantısı

Uygulamada SQL Server bağlantısı hem `App.config` dosyasında hem de `ConnectionManager.cs` gibi sınıflarda tanımlıdır. Bu alanlarda **kendi bilgisayarınıza uygun sunucu adı (Server Name)** ve gerekli durumlarda **kullanıcı adı/parola** gibi bilgileri girmeniz gerekir.

### Bağlantı dizesi örneği:

```xml
<!-- App.config içinde -->
<connectionStrings>
  <add name="AracKiralamaDB"
       connectionString="Server=YOUR_SERVER_NAME;Database=AracKiralama;Trusted_Connection=True;" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

```csharp
// ConnectionManager.cs içinde örnek kullanım
string connectionString = "Server=YOUR_SERVER_NAME;Database=AracKiralama;Trusted_Connection=True;";
```

> ❗ `YOUR_SERVER_NAME` kısmını kendi SQL Server örneğinizin adıyla değiştirin. Örneğin: `DESKTOP-1234\SQLEXPRESS` veya `localhost`.  
> Eğer Windows kimlik doğrulaması yerine SQL kimlik doğrulaması kullanıyorsanız bağlantı dizesi şu şekilde olabilir:  
> `Server=YOUR_SERVER_NAME;Database=AracKiralama;User Id=sqlusername;Password=sqlpassword;`

## 📌 Kurulum

1. Bu projeyi GitHub üzerinden kendi bilgisayarınıza klonlayın:
    ```bash
    git clone https://github.com/kullaniciadi/arac-kiralama-projesi.git
    ```

2. Visual Studio ile projeyi açın.

3. SQL Server'da `AracKiralama` adlı veritabanını oluşturun ve proje içinde bulunan `AracKiralama.sql` dosyasındaki script'i çalıştırarak tabloları oluşturun.

4. `App.config` ve `ConnectionManager.cs` dosyalarında yer alan **SQL Server bağlantı dizesini**, kendi bilgisayarınıza uygun şekilde güncelleyin.

5. Projeyi derleyin (`Ctrl+Shift+B`) ve uygulamayı çalıştırarak test edin.

## 📸 Ekran Görüntüleri

### Giriş Ekranı  
![Ana Ekran](screenshots/login.png)

### Kiralanabilir Araçlar  
![Araç Listesi](screenshots/homepage.png)

### Araç Kiralama Ekranı  
![Araç Kiralama](screenshots/rent.png)

### Kiralanan Aracı İptal Etme (Kullanıcı)  
![Kiralamayı İptal Etme](screenshots/user_rent_cancel.png)

### Admin Paneli  
![Araç Bilgilerini Görüntüleme ve Güncelleme](screenshots/admin_panel.png)

### Admin Kullanıcı Yönetimi  
![Kullanıcı Bilgilerini Görüntüleme ve Güncelleme](screenshots/admin_panel2.png)

### Admin Kiralanan Araçlar Yönetimi  
![Kiralanan Araçları Görüntüleme ve İptal Etme](screenshots/admin_rent_cancel.png)

---

Teşekkürler! 😊 Projeyi faydalı bulduysanız yıldız bırakmayı unutmayın. Geliştirme sürecine katkıda bulunmak isterseniz PR (Pull Request) gönderebilirsiniz.
