
# Proje Başlığı

AssignmentHafta2.API | WebAPI-NetCore


## Amaç

 - Rest standartlarna uygun olmalıdır. 
 - GET, POST, PUT, DELETE, PATCH methodları kullanılmalıdır. 
 - Http status code standartlarına uyulmalıdır. Error Handler ile 500, 400, 404, 200, 201 hatalarının standart format ile verilmesi. 
 - Modellerde zorunlu alanların kontrolü yapılmalıdır. 
 - Routing kullanılmalıdır. 
 - Model binding işlemleri hem body den hemde query den yapılacak şekilde örneklendirilmelidir. 
 - Bonus: Standart crud işlemlerine ek olarak, listeleme ve sıralama işlevleride eklenmelidir. Örn: /api/products/list?name=abc 
## API Kullanımı

#### Tüm Ürünleri Getir

```http
  GET /api/products
```


#### Ürünü Getir

```http
  GET /api/products/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Çağrılacak ürünün ID değeri |


#### Yeni Ürün Oluştur

```http
  POST /api/products/
```


#### Ürünü Güncelle

```http
  PUT /api/products/{id}
```
| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Güncellenecek ürünün ID değeri |



#### Ürünün Belirli Alanlarını Güncelle

```http
  PATCH /api/products/{id}
```
| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Güncellenecek ürünün ID değeri |


#### Ürünü Sil

```http
  DELETE /api/products/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Silinecek ürünün ID değeri |


#### Ürünü Getir

```http
  GET api/products/search?name=
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | Ürün adının içermesini istenilen text  |

#### Ürünleri Sıralayarak Getir

```http
  GET api/products/sort
```


## Kullanılan Teknolojiler

**Framework** .Net Core

**Proje Tipi** Console App

  