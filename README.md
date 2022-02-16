# Health Checks & Alerting System
using [Xabaril](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) 
& [Monika](https://monika.hyperjump.tech/) on ASP.NET Core


# About
Repository ini adalah code dari hasil sharing session di [SimpliDOTS](https://simplidots.com/) dengan topik 
Health Checks menggunakan Xabaril dan Alerting System menggunakan Monika.


## Slide
[Link Google Slide](https://docs.google.com/presentation/d/1NfcphDMWc-R4Dx-VGfSzVUim2ujRT5rJXcKxhas-XBY/edit?usp=sharing)


## Getting Started

#### Setup Container
Project ini menggunakan docker untuk keperluan Redis, SQL Server, dan juga RabbitMQ.
Untuk menjalaskan container2 di atas saya sudah melampirkan file docker-compose di projectnya, 
jadi cukup change directory ke project ini & tinggal up dockernya saja dengan perintah

```bash
docker-compose up
```


#### Change Monika Configuration
Untuk menjalankan notifikasi dengan Monika, terlebih dahulu Anda harus mengganti
slack configurasi dari Monika di project ini.
Jadi, cari file `monika.yml` lalu ganti nilai di bawah ini dengan nilai configurasi Anda sendiri.

```yaml
notifications:
  - id : "YOUR-SLACK-CHANNEL-ID"
    type: slack
    data:
      url: "YOUR-SLACK-WEBHOOK-URL"
```


#### Run Monika
Untuk menjalankan Monika, disini saya menggunakan docker. Pastikan direktori saat ini lagi di project ini,
lalu jalankan perintah dibawah

```docker
docker run --name monika -v ${PWD}/monika.yml:/config/monika.yml --de
tach hyperjump/monika:latest monika -c /config/monika.yml
```