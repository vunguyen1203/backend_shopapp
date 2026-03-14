-- password user: 123456
INSERT INTO shopapp.dbo.users (id,name,email,password,[role],is_blocked,created_at,updated_at) VALUES
	 (N'7f8471a8-8d0b-4a89-b501-58389a4f6d43',N'user1',N'user1@example.com',N'$2a$11$ehBQ1otFeM3qMi4nzUvk4uqYWZd07ujHiVipzGFm3etYBolY.y/6S',N'admin',0,'2026-01-27 09:21:55.4870000','2026-01-27 12:58:22.1670000'),
	 (N'ca0fbf1b-7f3a-4f43-9930-82587854dac5',N'user2',N'user2@example.com',N'$2a$11$zkjdppPKlutmUH8yjwc7COf4IKe.mqTPGncKC8yb7Kc3lacuM5tEG',N'mod',0,'2026-01-27 09:23:14.3030000','2026-02-08 01:11:04.8000000');

INSERT INTO shopapp.dbo.categories (id,name,slug,created_at,updated_at) VALUES
	 (N'0e57d93f-db86-4516-8932-e52bee54d722',N'Máy in',N'may-in','2026-01-27 13:00:55.0700000',NULL),
	 (N'1241c5fc-cde1-484d-80ee-a1f4e805dce9',N'Tablet',N'tablet','2026-01-27 13:07:39.4670000',NULL),
	 (N'397f1f57-b3fa-4525-bfce-4830b7c2468b',N'Laptop',N'laptop','2026-01-27 13:06:38.1930000',NULL),
	 (N'535d2139-134b-46b7-9116-1a9873d04cc4',N'Điện máy',N'dien-may','2026-01-27 13:49:52.3800000',NULL),
	 (N'56f3dd81-c69c-4fb2-b71c-565e9cb44efc',N'Làm đẹp',N'lam-dep','2026-01-27 13:07:01.3730000','2026-01-27 13:27:35.9900000'),
	 (N'8a321c88-04e9-41b0-b682-c6aa7bf4bd26',N'Đồ gia dụng',N'do-gia-dung','2026-01-27 13:50:00.3330000',NULL),
	 (N'ada734f8-c1aa-452e-b04a-5167b46f18dd',N'TV',N'tv','2026-01-27 13:07:05.6430000',NULL),
	 (N'dd0e46a2-ebbf-4728-85ad-1f2ee5408dc0',N'Camera',N'camera','2026-01-27 13:06:50.8530000',NULL),
	 (N'e13f04d3-ff96-477b-802d-34d76b274810',N'Mic thu âm',N'mic-thu-am','2026-01-27 13:06:31.7300000',NULL),
	 (N'e231ab0b-b441-41b2-baed-cb281091da4a',N'Âm thanh',N'am-thanh','2026-01-27 13:06:22.2970000',NULL);
INSERT INTO shopapp.dbo.categories (id,name,slug,created_at,updated_at) VALUES
	 (N'e739ad4a-5ed3-4710-a4d0-1d0c1affbac6',N'Đồng hồ',N'dong-ho','2026-01-27 13:49:43.9300000',NULL),
	 (N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'Điện thoại',N'dien-thoai','2026-01-27 13:49:27.3670000',NULL);

INSERT INTO shopapp.dbo.brands (id,name,slug,logo,created_at,updated_at) VALUES
	 (N'107263f0-23a8-4f5a-91ce-5359fa66dc31',N'Nothing',N'nothing',N'https://localhost:7121/images/brands/nothing.webp','2026-01-28 01:49:42.6930000','2026-02-06 12:56:48.1100000'),
	 (N'1db9c932-8120-4fd1-b3b9-db777e98f4ad',N'Masstel',N'masstel',N'https://localhost:7121/images/brands/masstel.webp','2026-01-28 01:52:20.5730000','2026-02-06 12:57:36.2630000'),
	 (N'32dcc54d-2747-4ccb-8c56-e2b4de198707',N'Gigabyte',N'gigabyte',N'https://localhost:7121/images/brands/gigabyte.webp','2026-01-28 01:57:00.8500000','2026-02-06 12:58:07.1030000'),
	 (N'36255fb6-7f39-4a10-aac9-da6db249edbb',N'Nubia',N'nubia',N'https://localhost:7121/images/brands/nubia_zte.webp','2026-01-28 01:48:46.9730000','2026-02-06 12:58:37.3670000'),
	 (N'46d7ee11-0042-40a3-9434-3dff6b188373',N'Xiaomi',N'xiaomi',N'https://localhost:7121/images/brands/xiaomi.webp','2026-01-28 01:41:19.8400000','2026-02-06 12:58:57.1370000'),
	 (N'521042af-5d3f-4bda-b354-cd4ddf3bf874',N'Realme',N'realme',N'https://localhost:7121/images/brands/realme.webp','2026-01-28 01:52:35.0870000','2026-02-06 12:59:14.8070000'),
	 (N'56b70ecb-d7de-4873-8e4a-a7f926d64084',N'Infinix',N'infinix',N'https://localhost:7121/images/brands/infinixlogo02.webp','2026-01-28 01:49:30.3030000','2026-02-06 12:59:41.8830000'),
	 (N'59f9ba49-42d5-494b-a0de-4e3388d51def',N'Samsung',N'samsung',N'https://localhost:7121/images/brands/brand-icon-samsung_2.png','2026-01-28 01:39:41.7870000','2026-02-06 13:00:01.7200000'),
	 (N'71aa12a2-abb1-4d32-862c-e2dc3435b6c7',N'Oppo',N'oppo',N'https://localhost:7121/images/brands/oppo.webp','2026-01-28 01:41:46.3800000','2026-02-06 13:00:23.1330000'),
	 (N'79d2aaf9-c3f2-4cd4-b341-353649fe068b',N'Itel',N'itel',N'https://localhost:7121/images/brands/itel.webp','2026-01-28 01:52:46.9870000','2026-02-06 13:00:56.5270000');
INSERT INTO shopapp.dbo.brands (id,name,slug,logo,created_at,updated_at) VALUES
	 (N'8b7c47f4-976e-4493-b761-cf0d5b4cd095',N'Honor',N'honor',N'https://localhost:7121/images/brands/HONOR.webp','2026-01-28 01:48:27.7000000','2026-02-06 13:01:20.6600000'),
	 (N'930eb642-c736-4773-b436-104080149e0d',N'Lenovo',N'lenovo',N'https://localhost:7121/images/brands/lenovo_logo_2015.svg.webp','2026-01-28 01:54:55.6470000','2026-02-06 13:01:39.6970000'),
	 (N'a4d14850-9eb0-4631-bad2-484f97b1289e',N'Nokia',N'nokia',N'https://localhost:7121/images/brands/nokia_1.webp','2026-01-28 01:49:17.2300000','2026-02-06 13:01:57.6030000'),
	 (N'abe3467a-03d4-41f4-be98-c7ee8e12b7f9',N'HP',N'hp',N'https://localhost:7121/images/brands/hp.webp','2026-01-28 01:58:51.7100000','2026-02-06 13:02:31.1230000'),
	 (N'b2a57711-5fa2-4491-b89c-d2d94f93c53d',N'Huawei',N'huawei',N'https://localhost:7121/images/brands/huawei.svg','2026-01-28 01:53:41.2770000','2026-02-06 13:03:13.9500000'),
	 (N'bd7ef391-d9ad-409b-a422-7e96f659fdba',N'MSI',N'msi',N'https://localhost:7121/images/brands/brand-msi.svg','2026-01-28 01:56:47.3070000','2026-02-06 13:03:33.8170000'),
	 (N'c9e8405d-3d44-4954-93f1-0b0aabeb5f2d',N'Tecno',N'tecno',N'https://localhost:7121/images/brands/tecno.webp','2026-01-28 01:42:14.3570000','2026-02-06 13:04:45.8300000'),
	 (N'cdc860cf-e8b9-4e01-9bd1-ceb5ed4175c7',N'LG',N'lg',N'https://localhost:7121/images/brands/lg.webp','2026-01-28 01:56:38.4430000','2026-02-06 13:05:04.0400000'),
	 (N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',N'Apple',N'apple',N'https://localhost:7121/images/brands/apple.webp','2026-01-28 01:40:52.4730000','2026-02-06 13:05:38.7500000'),
	 (N'd9289221-62ae-41c4-8986-d002e83c6f90',N'Acer',N'acer',N'https://localhost:7121/images/brands/acer.webp','2026-01-28 01:55:41.3870000','2026-02-06 13:05:59.0800000');
INSERT INTO shopapp.dbo.brands (id,name,slug,logo,created_at,updated_at) VALUES
	 (N'e19a3526-dc71-425f-b279-1a99fdb0132a',N'Sony',N'sony',N'https://localhost:7121/images/brands/brand-icon-sony_2.webp','2026-01-28 01:49:01.0970000','2026-02-06 13:06:33.0470000'),
	 (N'ee65e470-f238-4d02-ab21-a931989afa69',N'ZTE',N'zte',N'https://localhost:7121/images/brands/nubia_zte.webp','2026-01-28 01:48:40.1700000','2026-02-06 13:06:54.2330000'),
	 (N'f2a04ecb-9e64-4044-8c0f-da1da9f3eea7',N'Asus',N'asus',N'https://localhost:7121/images/brands/asus.webp','2026-01-28 01:54:23.8070000','2026-02-06 13:07:12.5230000'),
	 (N'fc6f1833-2d46-464a-ba23-1251c7795231',N'Dell',N'dell',N'https://localhost:7121/images/brands/dell_logo_1.webp','2026-01-28 01:55:20.1430000','2026-02-06 13:07:27.7530000');

INSERT INTO shopapp.dbo.vouchers (id,code,discount_percent,start_date,end_date,is_active,creadted_at,updated_at) VALUES
	 (N'6b70b773-303e-4036-8995-c88a44f37903',N'KM10',10,'2026-02-26 08:25:33.6040000','2026-03-26 08:25:33.6040000',1,'2026-02-26 15:25:52.5545945',NULL),
	 (N'893eee61-bf4e-43e7-b75a-562bf5e56baa',N'KM90',90,'2026-02-26 08:25:33.6040000','2026-03-26 08:25:33.6040000',1,'2026-02-26 15:26:28.7729675',NULL),
	 (N'97b80868-a1e1-479d-91b6-39170aaa7222',N'KM50',50,'2026-02-26 08:25:33.6040000','2026-03-26 08:25:33.6040000',1,'2026-02-26 15:26:09.3099730',NULL),
	 (N'ae6db286-a31f-4b36-b568-d0a35c5336b5',N'KM30',30,'2026-02-26 08:25:33.6040000','2026-03-26 08:25:33.6040000',1,'2026-02-26 15:26:02.0085016',NULL),
	 (N'f82d4fb4-e00d-470d-8266-3be949196133',N'KM70',70,'2026-02-26 08:25:33.6040000','2026-03-26 08:25:33.6040000',1,'2026-02-26 15:26:16.8274544',NULL);

INSERT INTO shopapp.dbo.products (id,name,slug,description,category_id,brand_id,[view],created_at,updated_at) VALUES
	 (N'15d9f1e5-59d5-42f6-be8f-3f7a4d03af57',N'Xiaomi Redmi Note 15 Pro 12GB 256GB',N'xiaomi-redmi-note-15-pro-12gb-256gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:18:41.8209100',NULL),
	 (N'36585325-5ee6-4aca-9182-a9577fc9841d',N'Xiaomi Redmi Note 15 6GB 128GB',N'xiaomi-redmi-note-15-6gb-128',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:16:22.9605251',NULL),
	 (N'41cae362-50e2-4e5b-8b13-1e02418b3094',N'iPhone 17 Pro 256GB',N'iphone-17-pro-256gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 07:56:57.5970000',NULL),
	 (N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'iPhone 17 512GB',N'iphone-17-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 07:56:44.0926962',NULL),
	 (N'61bae12e-1b3c-4dab-a16e-c3cbf7099158',N'iPhone 17 Pro 1TB',N'iphone-17-pro-1tb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 07:57:16.2540141',NULL),
	 (N'69e1c3c9-a109-4673-8dcd-cd7693369629',N'iPhone 17 Pro Max 512GB',N'iphone-17-pro-max-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 01:09:54.5025266',NULL),
	 (N'6c49ab56-a04c-4882-ad58-a7642cabe3a4',N'Xiaomi Redmi Note 15 Pro 5G 12GB 256GB',N'xiaomi-redmi-note-15-pro-5g-12gb-256gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:18:50.6518152',NULL),
	 (N'6c9e781d-19d8-4e17-8d6f-2dc6cf2a0008',N'Xiaomi Redmi Note 15 5G 6GB 128GB',N'xiaomi-redmi-note-15-5g-6gb-128',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:16:53.8184027',NULL),
	 (N'755700af-0dee-42b4-8042-f7d4256717ed',N'iPhone 17 Pro Max 1TB',N'iphone-17-pro-max-1tb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 01:10:11.8663460',NULL),
	 (N'7991c11b-23c7-4e79-88e9-c001e2c9a3cd',N'Xiaomi 15T Pro 12GB 512GB',N'xiaomi-15t-pro-12gb-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:19:55.8425422',NULL);
INSERT INTO shopapp.dbo.products (id,name,slug,description,category_id,brand_id,[view],created_at,updated_at) VALUES
	 (N'b4b11252-20cc-42b1-b8d2-619807f3faf9',N'Xiaomi 15T 12GB 512GB',N'xiaomi-15t-12gb-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:19:34.3891916',NULL),
	 (N'c354299a-4724-495a-aa43-65cf041516f6',N'iPhone 17 Pro 512GB',N'iphone-17-pro-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 07:57:05.7330000',NULL),
	 (N'cd5f5312-ddfe-49ca-aea1-d3b5a3734c1e',N'iPhone 17 Pro Max 256GB',N'iphone-17-pro-max-256gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-25 13:28:39.5297373',NULL),
	 (N'e12e801b-d8b2-4566-b9cb-8ec87a129a45',N'Xiaomi 17 Ultra 16GB 512GB',N'xiaomi-17-ultra-16gb-512gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'46d7ee11-0042-40a3-9434-3dff6b188373',0,'2026-02-26 09:49:06.0381023',NULL),
	 (N'e2cdb533-199d-4608-a824-67cff8b2fb22',N'iPhone 17 Pro Max 2TB',N'iphone-17-pro-max-2tb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 01:10:17.6041363',NULL),
	 (N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'iPhone 17 256GB',N'iphone-17-256gb',NULL,N'f24e26be-7684-4a1e-8b27-b40ae7fc11f6',N'd2e396f6-7c7a-4f31-ae58-beb03ca18b38',0,'2026-02-26 07:56:30.6747008',NULL);

INSERT INTO shopapp.dbo.variants (id,product_id,sku,price,stock,color,attributes_orther,is_main,created_at,updated_at) VALUES
	 (N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'69e1c3c9-a109-4673-8dcd-cd7693369629',N'IP-17-PRO-MAX-512GB-SLI',42990000,20,N'sliver',NULL,1,'2026-02-26 09:04:25.8022252',NULL),
	 (N'018a7d74-b334-4268-8999-341b7a89bed6',N'15d9f1e5-59d5-42f6-be8f-3f7a4d03af57',N'XM-RM-N15-PRO-12GB-256GB-BUE',9290000.0,20,N'blue',NULL,1,'2026-02-26 09:35:56.0598218',NULL),
	 (N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'c354299a-4724-495a-aa43-65cf041516f6',N'IP-17-PRO-512GB-DBLU',39690000,20,N'dark blue',NULL,1,'2026-02-26 08:49:24.4214015',NULL),
	 (N'051b18e4-349f-4476-a0da-4bfdf8fba804',N'15d9f1e5-59d5-42f6-be8f-3f7a4d03af57',N'XM-RM-N15-PRO-12GB-256GB-BLK',9290000.0,20,N'black',NULL,0,'2026-02-26 09:38:01.6190617',NULL),
	 (N'10758b1a-0127-4f00-bb1d-88a133df0187',N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'IP-17-256GB-GRE',24190000,20,N'green',NULL,1,'2026-02-26 08:30:35.7130369',NULL),
	 (N'165f9138-5dff-4529-9e45-f85bd967e25d',N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'IP-17-512GB-WHI',30490000,20,N' white',NULL,0,'2026-02-26 08:35:25.9869358',NULL),
	 (N'1fb3fc97-98b2-434b-b92c-5cecc0dc639e',N'7991c11b-23c7-4e79-88e9-c001e2c9a3cd',N'XM-15T-PRO-12GB-512GB-GOL',16990000,20,N'gold',NULL,0,'2026-02-26 09:48:00.4555533',NULL),
	 (N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'IP-17-512GB-PUR',30490000,20,N'  purple',NULL,0,'2026-02-26 08:38:02.1444810',NULL),
	 (N'278e36fc-dc3f-4f7c-b591-8dc98484215d',N'6c9e781d-19d8-4e17-8d6f-2dc6cf2a0008',N'XM-RM-N15-5G-6GB-128GB-BUE',6990000.0,20,N'blue',NULL,0,'2026-02-26 09:32:23.7497389',NULL),
	 (N'2f60dd30-4fe1-4fe4-ab21-98831ba246b3',N'36585325-5ee6-4aca-9182-a9577fc9841d',N'XM-RM-N15-6GB-128GB-BLU',5590000.0,20,N'blue',NULL,1,'2026-02-26 09:24:44.3366139',NULL);
INSERT INTO shopapp.dbo.variants (id,product_id,sku,price,stock,color,attributes_orther,is_main,created_at,updated_at) VALUES
	 (N'39d09f4a-d44c-4f65-aa65-69527854a22a',N'b4b11252-20cc-42b1-b8d2-619807f3faf9',N'XM-15T-12GB-512GB-GOL',12490000,20,N'gold',NULL,1,'2026-02-26 09:45:25.6259712',NULL),
	 (N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'cd5f5312-ddfe-49ca-aea1-d3b5a3734c1e',N'IP-17-PRO-MAX-256GB-ORA',36990000,20,N'orange',NULL,0,'2026-02-26 08:59:02.9269297',NULL),
	 (N'4acac477-84ee-4fe2-816a-3be11cb1370f',N'6c49ab56-a04c-4882-ad58-a7642cabe3a4',N'XM-RM-N15-PRO-5G-12GB-256GB-BLK',10690000,20,N'black',NULL,0,'2026-02-26 09:41:23.0597955',NULL),
	 (N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'IP-17-256GB-BLU',24190000,20,N' blue',NULL,0,'2026-02-26 08:33:05.3316095',NULL),
	 (N'4d0d8171-af96-4960-a13d-7f184a432a62',N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'IP-17-512GB-BLU',30490000,20,N' blue',NULL,1,'2026-02-26 08:37:10.0437979',NULL),
	 (N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'e2cdb533-199d-4608-a824-67cff8b2fb22',N'IP-17-PRO-MAX-2TB-DBLU',62490000,20,N'dark blue',NULL,0,'2026-02-26 09:12:01.2719983',NULL),
	 (N'5caadb91-939d-49cb-85d5-a70f52514846',N'e12e801b-d8b2-4566-b9cb-8ec87a129a45',N'XM-17-ULTRA-16GB-512GB-GRE',39990000,20,N'green',NULL,1,'2026-02-26 09:51:40.2674077',NULL),
	 (N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'69e1c3c9-a109-4673-8dcd-cd7693369629',N'IP-17-PRO-MAX-512GB-ORA',42990000,20,N'orange',NULL,0,'2026-02-26 09:03:01.9064845',NULL),
	 (N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'cd5f5312-ddfe-49ca-aea1-d3b5a3734c1e',N'IP-17-PRO-MAX-256GB-SLI',36990000,20,N'sliver',NULL,0,'2026-02-26 08:57:52.3432422',NULL),
	 (N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'c354299a-4724-495a-aa43-65cf041516f6',N'IP-17-PRO-512GB-ORA',39690000,20,N'orange',NULL,0,'2026-02-26 08:50:46.9180147',NULL);
INSERT INTO shopapp.dbo.variants (id,product_id,sku,price,stock,color,attributes_orther,is_main,created_at,updated_at) VALUES
	 (N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'61bae12e-1b3c-4dab-a16e-c3cbf7099158',N'IP-17-PRO-1TB-DBLU',45990000,20,N'dark blue',NULL,0,'2026-02-26 08:54:47.0008308',NULL),
	 (N'79a605c6-b56d-4ee6-be4c-e00b82e456b6',N'15d9f1e5-59d5-42f6-be8f-3f7a4d03af57',N'XM-RM-N15-PRO-12GB-256GB-GRE',9290000.0,20,N'grey',NULL,0,'2026-02-26 09:37:23.6152460',NULL),
	 (N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'IP-17-512GB-BLK',30490000,20,N' black',NULL,0,'2026-02-26 08:36:33.9247244',NULL),
	 (N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'61bae12e-1b3c-4dab-a16e-c3cbf7099158',N'IP-17-PRO-1TB-SLI',45990000,20,N'sliver',NULL,0,'2026-02-26 08:53:26.4141329',NULL),
	 (N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'IP-17-256GB-WHI',24190000,20,N' white',NULL,0,'2026-02-26 08:34:53.5911791',NULL),
	 (N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'IP-17-256GB-BLK',24190000,20,N' black',NULL,0,'2026-02-26 08:34:19.2244389',NULL),
	 (N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'c354299a-4724-495a-aa43-65cf041516f6',N'IP-17-PRO-512GB-SLI',39690000,20,N'sliver',NULL,0,'2026-02-26 08:50:00.9937751',NULL),
	 (N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'41cae362-50e2-4e5b-8b13-1e02418b3094',N'IP-17-PRO-256GB-DBLU',33290000,20,N'  dark blue',NULL,0,'2026-02-26 08:46:09.8456827',NULL),
	 (N'9345b995-0142-44a8-817d-7a292d9d9720',N'755700af-0dee-42b4-8042-f7d4256717ed',N'IP-17-PRO-MAX-1TB-ORA',50990000,20,N'orange',NULL,1,'2026-02-26 09:08:30.0938151',NULL),
	 (N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'755700af-0dee-42b4-8042-f7d4256717ed',N'IP-17-PRO-MAX-1TB-DBLU',50990000,20,N'dark blue',NULL,0,'2026-02-26 09:07:14.1290574',NULL);
INSERT INTO shopapp.dbo.variants (id,product_id,sku,price,stock,color,attributes_orther,is_main,created_at,updated_at) VALUES
	 (N'94e338c2-fc6c-45a9-b07e-e621ec938eb6',N'36585325-5ee6-4aca-9182-a9577fc9841d',N'XM-RM-N15-6GB-128GB-PUR',5590000.0,20,N'purple',NULL,0,'2026-02-26 09:25:55.6197207',NULL),
	 (N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'e4e5d8bf-2942-4dd1-b201-a89f5143fca3',N'IP-17-256GB-PUR',24190000,20,N' purple',NULL,0,'2026-02-26 08:32:26.9362497',NULL),
	 (N'c35307d8-8775-40d6-b7bf-95af3e7d1731',N'e12e801b-d8b2-4566-b9cb-8ec87a129a45',N'XM-17-ULTRA-16GB-512GB-WHI',39990000,20,N'white',NULL,0,'2026-02-26 09:52:00.7804809',NULL),
	 (N'c945145f-7bc1-4493-aa86-4e00981349a3',N'41cae362-50e2-4e5b-8b13-1e02418b3094',N'IP-17-PRO-256GB-SLI',33290000,20,N'  sliver',NULL,1,'2026-02-26 08:44:24.2431166',NULL),
	 (N'cefce310-fec8-4ae5-afd4-ec0d4f83d3fc',N'6c9e781d-19d8-4e17-8d6f-2dc6cf2a0008',N'XM-RM-N15-5G-6GB-128GB-PUR',6990000.0,20,N'purple',NULL,1,'2026-02-26 09:31:01.1636254',NULL),
	 (N'd1cae663-c483-45e2-9580-8d724a9c1e92',N'6c49ab56-a04c-4882-ad58-a7642cabe3a4',N'XM-RM-N15-PRO-5G-12GB-256GB-PUR',10690000,20,N'purple',NULL,1,'2026-02-26 09:42:49.0656083',NULL),
	 (N'daf19b82-9272-4f23-871e-bd9e648dc32b',N'7991c11b-23c7-4e79-88e9-c001e2c9a3cd',N'XM-15T-PRO-12GB-512GB-GRE',16990000,20,N'grey',NULL,1,'2026-02-26 09:47:39.4998022',NULL),
	 (N'dbbc2bc4-028c-46a5-8e0c-7d15fb4f362d',N'6c49ab56-a04c-4882-ad58-a7642cabe3a4',N'XM-RM-N15-PRO-5G-12GB-256GB-GRE',10690000,20,N'grey',NULL,0,'2026-02-26 09:42:01.2988158',NULL),
	 (N'e337af94-093b-4594-b621-24d097991bb8',N'b4b11252-20cc-42b1-b8d2-619807f3faf9',N'XM-15T-12GB-512GB-BLK',12490000,20,N'black',NULL,0,'2026-02-26 09:45:44.7007446',NULL),
	 (N'e647d21a-d03a-4822-83e8-0c394791674e',N'61bae12e-1b3c-4dab-a16e-c3cbf7099158',N'IP-17-PRO-1TB-ORA',45990000,20,N'orange',NULL,1,'2026-02-26 08:52:22.2098677',NULL);
INSERT INTO shopapp.dbo.variants (id,product_id,sku,price,stock,color,attributes_orther,is_main,created_at,updated_at) VALUES
	 (N'e865bcf6-af61-4e14-875d-1df6040cdace',N'41cae362-50e2-4e5b-8b13-1e02418b3094',N'IP-17-PRO-256GB-ORA',33290000,20,N'orange',NULL,0,'2026-02-26 08:47:15.9450690',NULL),
	 (N'ee07f6d0-5b22-49ba-9a4c-ecad7d28e309',N'36585325-5ee6-4aca-9182-a9577fc9841d',N'XM-RM-N15-6GB-128GB-BLK',5590000.0,20,N'black',NULL,0,'2026-02-26 09:25:16.6470449',NULL),
	 (N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'cd5f5312-ddfe-49ca-aea1-d3b5a3734c1e',N'IP-17-PRO-MAX-256GB-DBLU',36990000,20,N'dark blue',NULL,1,'2026-02-26 08:57:07.7319941',NULL),
	 (N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'e2cdb533-199d-4608-a824-67cff8b2fb22',N'IP-17-PRO-MAX-2TB-SLI',62490000,20,N'sliver',NULL,1,'2026-02-26 09:11:28.9333423',NULL),
	 (N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'4d732b1b-fd70-4dd8-9188-79acbfd6c60d',N'IP-17-512GB-GRE',30490000,20,N'  green',NULL,0,'2026-02-26 08:39:57.0833129',NULL),
	 (N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'e2cdb533-199d-4608-a824-67cff8b2fb22',N'IP-17-PRO-MAX-2TB-ORA',62490000,20,N'orange',NULL,0,'2026-02-26 09:10:21.2116675',NULL),
	 (N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'69e1c3c9-a109-4673-8dcd-cd7693369629',N'IP-17-PRO-MAX-512GB-DBLU',42990000,20,N'dark blue',NULL,0,'2026-02-26 09:05:38.4293461',NULL),
	 (N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'755700af-0dee-42b4-8042-f7d4256717ed',N'IP-17-PRO-MAX-1TB-SLI',50990000,20,N'sliver',NULL,0,'2026-02-26 09:07:53.4597856',NULL),
	 (N'ffecf353-d208-4a61-b6a9-3b2d320f3f36',N'6c9e781d-19d8-4e17-8d6f-2dc6cf2a0008',N'XM-RM-N15-5G-6GB-128GB-BLK',6990000.0,20,N'black',NULL,0,'2026-02-26 09:31:34.0755346',NULL);

INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'002ca1a1-589d-49e4-8416-2145a6d10a03',N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 08:54:47.0099289'),
	 (N'0034428a-dfdc-4bd2-8d7e-b5c756db37cb',N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'https://localhost:7121/images/product/288663120.jpeg',0,'2026-02-26 08:39:57.0944671'),
	 (N'007a5fb0-76ea-4b17-bef2-51135d16853f',N'10758b1a-0127-4f00-bb1d-88a133df0187',N'https://localhost:7121/images/product/288663120.jpeg',0,'2026-02-26 08:30:35.7295334'),
	 (N'00d43a5a-53c2-4d23-bc0d-3b60483c58d7',N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 08:59:02.9372057'),
	 (N'013b6061-5714-4bfa-9d22-7782a8773bda',N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 09:11:28.9455301'),
	 (N'024e70f4-fc61-4c3a-8935-104882fca0ba',N'ffecf353-d208-4a61-b6a9-3b2d320f3f36',N'https://localhost:7121/images/product/1082208470.jpeg',0,'2026-02-26 09:31:34.0956600'),
	 (N'038956b6-7aed-40e3-a3a6-7d20f7c575ee',N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 09:11:28.9428699'),
	 (N'05580cd9-deaa-4533-8f75-dd2fa5301f9a',N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 08:54:47.0104549'),
	 (N'05ca4c35-1724-4b31-91fc-94324f547e19',N'e865bcf6-af61-4e14-875d-1df6040cdace',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 08:47:15.9565137'),
	 (N'06131af2-d63f-4a9f-b10e-845a3dd22c5a',N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 08:49:24.4340417');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'0848624f-84d7-46f3-a01f-49a382d06119',N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 08:49:24.4326573'),
	 (N'08cc9afb-1d41-41db-b9e2-5bfc684b756f',N'ee07f6d0-5b22-49ba-9a4c-ecad7d28e309',N'https://localhost:7121/images/product/1656802530.jpeg',1,'2026-02-26 09:25:16.6846291'),
	 (N'094dd48e-1d81-495c-9faa-6573505fd063',N'9345b995-0142-44a8-817d-7a292d9d9720',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 09:08:30.1063045'),
	 (N'09832988-e3ed-4cf6-ae3d-2dfc9610bd84',N'daf19b82-9272-4f23-871e-bd9e648dc32b',N'https://localhost:7121/images/product/194538600.jpeg',0,'2026-02-26 09:47:39.5108689'),
	 (N'098a9a2a-332e-4cc8-80eb-e7edfe5960d8',N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 08:50:01.0034244'),
	 (N'09ee5fb5-d71f-4b0f-a835-dd1a75f7081d',N'10758b1a-0127-4f00-bb1d-88a133df0187',N'https://localhost:7121/images/product/1648747165.jpeg',0,'2026-02-26 08:30:35.7249463'),
	 (N'0b0c4fd8-f071-47d0-8560-8f4880b8cdfc',N'e337af94-093b-4594-b621-24d097991bb8',N'https://localhost:7121/images/product/1376754420.jpeg',1,'2026-02-26 09:45:44.7089146'),
	 (N'0d55e385-6542-4c74-8474-b7d9ce8c6ae5',N'94e338c2-fc6c-45a9-b07e-e621ec938eb6',N'https://localhost:7121/images/product/2086530298.jpeg',0,'2026-02-26 09:25:55.6486259'),
	 (N'0eb0a54d-d19b-47bd-81f6-aed43e0b618b',N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 09:04:25.8115305'),
	 (N'107d931a-89ef-4859-ba4b-78ea2f5890df',N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 08:50:01.0024786');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'11d608a1-11e9-4140-8640-5d0a474c0f40',N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 08:46:09.8630481'),
	 (N'12db617f-aba8-48f7-bc70-aef245a3b017',N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 09:07:14.1425265'),
	 (N'13be09c8-dab6-4a83-837c-c28c420cae53',N'4acac477-84ee-4fe2-816a-3be11cb1370f',N'https://localhost:7121/images/product/2092958550.jpeg',1,'2026-02-26 09:41:23.0678620'),
	 (N'1536036e-3724-4dc3-9f7e-155dc626864b',N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 09:10:21.2224435'),
	 (N'16202c28-7df4-45d4-a973-1bd830f22384',N'5caadb91-939d-49cb-85d5-a70f52514846',N'https://localhost:7121/images/product/1881027751.jpeg',0,'2026-02-26 09:51:40.2790962'),
	 (N'19e15d55-63bc-4967-9352-917d2032d1ff',N'051b18e4-349f-4476-a0da-4bfdf8fba804',N'https://localhost:7121/images/product/1455010474.jpeg',0,'2026-02-26 09:38:01.6480325'),
	 (N'19f8b59a-d1ff-46a4-9f3f-8aa6723db0d1',N'cefce310-fec8-4ae5-afd4-ec0d4f83d3fc',N'https://localhost:7121/images/product/1195059909.jpeg',1,'2026-02-26 09:31:01.1718207'),
	 (N'1ba0b1c9-7f52-4dd6-a7d6-64add8dab977',N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 09:04:25.8152494'),
	 (N'1bc71ef7-3b47-4e5d-ac1c-6e37c6308eca',N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'https://localhost:7121/images/product/1532109428.jpeg',1,'2026-02-26 08:33:05.3398629'),
	 (N'1e2ebcf0-abd0-4897-a074-cd191c2a43c8',N'9345b995-0142-44a8-817d-7a292d9d9720',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 09:08:30.1018852');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'1f5b6937-c1f2-4594-9269-bdd20836f199',N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'https://localhost:7121/images/product/1444935507.jpeg',1,'2026-02-26 08:34:53.6007698'),
	 (N'1f5d693b-6da2-4475-90be-628710d5fdb7',N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 09:07:14.1406254'),
	 (N'1f66860f-13e8-445a-bd62-8faafa969f68',N'4d0d8171-af96-4960-a13d-7f184a432a62',N'https://localhost:7121/images/product/183644029.jpeg',0,'2026-02-26 08:37:10.0597999'),
	 (N'1fcf26c2-f6d6-4881-873d-bb25e938b882',N'278e36fc-dc3f-4f7c-b591-8dc98484215d',N'https://localhost:7121/images/product/280795115.jpeg',0,'2026-02-26 09:32:23.7591597'),
	 (N'222a814c-6378-469e-bc59-5901b663e143',N'd1cae663-c483-45e2-9580-8d724a9c1e92',N'https://localhost:7121/images/product/815463394.jpeg',0,'2026-02-26 09:42:49.0795079'),
	 (N'22aba540-2b4d-4232-ada9-67a69b393744',N'4acac477-84ee-4fe2-816a-3be11cb1370f',N'https://localhost:7121/images/product/1156718318.jpeg',0,'2026-02-26 09:41:23.0709696'),
	 (N'2449aee1-8565-4bda-a88e-10e3455f0b56',N'79a605c6-b56d-4ee6-be4c-e00b82e456b6',N'https://localhost:7121/images/product/893313750.jpeg',0,'2026-02-26 09:37:23.6402371'),
	 (N'2474b4d1-ce66-4631-a545-371109804059',N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'https://localhost:7121/images/product/1416408118.jpeg',0,'2026-02-26 08:32:26.9628839'),
	 (N'256d2f2a-ffb2-49b2-bcf7-45e4596caed3',N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'https://localhost:7121/images/product/1564664647.jpeg',0,'2026-02-26 08:33:05.3414111'),
	 (N'25851e1c-5f6e-4805-aa33-5da463c4d6c2',N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 09:10:21.2236800');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'278d36f6-c60e-484c-afaa-1957d22b4d43',N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 09:07:53.4847135'),
	 (N'2a780928-52a1-4307-9965-bd660000563e',N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'https://localhost:7121/images/product/1020805043.jpeg',1,'2026-02-26 08:36:33.9499000'),
	 (N'2e1c9962-5921-4f5f-8cb7-1e0d7dd03b18',N'daf19b82-9272-4f23-871e-bd9e648dc32b',N'https://localhost:7121/images/product/1243798384.jpeg',1,'2026-02-26 09:47:39.5095247'),
	 (N'2f3801b5-b4ee-48c2-8be3-06e5301caf14',N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'https://localhost:7121/images/product/1561851845.jpeg',1,'2026-02-26 08:32:26.9573801'),
	 (N'305ee68a-f41d-45cc-8193-3d467019e522',N'4acac477-84ee-4fe2-816a-3be11cb1370f',N'https://localhost:7121/images/product/332251884.jpeg',0,'2026-02-26 09:41:23.0698068'),
	 (N'36b08fab-1b59-4556-bb05-2d92853a5951',N'd1cae663-c483-45e2-9580-8d724a9c1e92',N'https://localhost:7121/images/product/630426684.jpeg',0,'2026-02-26 09:42:49.0806281'),
	 (N'3741661d-21cb-4ffc-b39a-aa12cd1d1265',N'10758b1a-0127-4f00-bb1d-88a133df0187',N'https://localhost:7121/images/product/845672068.jpeg',0,'2026-02-26 08:30:35.7257823'),
	 (N'39b3a57f-dd55-484f-af53-40c8962026f4',N'051b18e4-349f-4476-a0da-4bfdf8fba804',N'https://localhost:7121/images/product/440293.jpeg',1,'2026-02-26 09:38:01.6437106'),
	 (N'3a33ff91-1303-4e59-8348-40aedfb20996',N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'https://localhost:7121/images/product/1997379673.jpeg',0,'2026-02-26 08:34:53.6054820'),
	 (N'3b64abd3-76d4-4cc9-921a-602d5cd251bb',N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 08:53:26.4275251');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'3d82a124-7b7d-44ad-bc92-af9fce0895c3',N'4d0d8171-af96-4960-a13d-7f184a432a62',N'https://localhost:7121/images/product/1564664647.jpeg',0,'2026-02-26 08:37:10.0561560'),
	 (N'3ed3b42b-4fb5-4517-aa01-4d598a20a036',N'79a605c6-b56d-4ee6-be4c-e00b82e456b6',N'https://localhost:7121/images/product/2141455884.jpeg',0,'2026-02-26 09:37:23.6310734'),
	 (N'3faf2f97-1d5d-4bcc-9eed-6d1155d034ad',N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 08:50:01.0229094'),
	 (N'40458785-870d-4e90-a843-f8e50843be23',N'5caadb91-939d-49cb-85d5-a70f52514846',N'https://localhost:7121/images/product/1337409679.jpeg',1,'2026-02-26 09:51:40.2747819'),
	 (N'412008b3-9f9c-4f93-8e94-19a73c25df29',N'dbbc2bc4-028c-46a5-8e0c-7d15fb4f362d',N'https://localhost:7121/images/product/196802130.jpeg',0,'2026-02-26 09:42:01.3102760'),
	 (N'453afdcb-6fcc-4a72-a23c-259e75b74a66',N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 09:12:01.2858902'),
	 (N'457173a7-0359-43e7-8baf-4b9bf835c67b',N'ee07f6d0-5b22-49ba-9a4c-ecad7d28e309',N'https://localhost:7121/images/product/343734171.jpeg',0,'2026-02-26 09:25:16.6919082'),
	 (N'47ae2bec-9f75-4d0f-a0a0-508feaf61ca3',N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 08:49:24.4317690'),
	 (N'48c2d9cb-545f-4d34-8d25-ffed6c56d47e',N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 08:59:02.9362684'),
	 (N'4b8cd01c-294a-438c-88a4-31f28e13f29e',N'ffecf353-d208-4a61-b6a9-3b2d320f3f36',N'https://localhost:7121/images/product/290743969.jpeg',0,'2026-02-26 09:31:34.0983851');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'4b9e0f20-004c-41a8-b72e-383f89251925',N'4d0d8171-af96-4960-a13d-7f184a432a62',N'https://localhost:7121/images/product/836800855.jpeg',0,'2026-02-26 08:37:10.0588508'),
	 (N'4c29f2b3-442b-42c4-9280-8480ff9c82ee',N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 08:54:47.0081235'),
	 (N'4e5d067e-feba-4f28-a6bd-f8068e8a0b95',N'd1cae663-c483-45e2-9580-8d724a9c1e92',N'https://localhost:7121/images/product/1098714913.jpeg',0,'2026-02-26 09:42:49.0784137'),
	 (N'4e6d982e-7840-4beb-bbdd-9d5e77407b8a',N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'https://localhost:7121/images/product/1673125760.jpeg',0,'2026-02-26 08:36:33.9558092'),
	 (N'4f4e20b2-ed07-40fe-acbd-4da4ac98098f',N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'https://localhost:7121/images/product/1020137047.jpeg',0,'2026-02-26 08:34:53.6017009'),
	 (N'515c5840-b4cd-4db2-bf74-e7d360cde262',N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 08:59:02.9377974'),
	 (N'51f3383f-bd27-484e-acff-a86df32c2427',N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'https://localhost:7121/images/product/836800855.jpeg',0,'2026-02-26 08:33:05.3431859'),
	 (N'5497b03f-280d-4cff-b9fb-4096ca1abb0f',N'1fb3fc97-98b2-434b-b92c-5cecc0dc639e',N'https://localhost:7121/images/product/1649108781.jpeg',0,'2026-02-26 09:48:00.4779780'),
	 (N'54a8542e-0ac8-4c5c-a1aa-c3922cd269e5',N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 08:50:46.9334740'),
	 (N'56a23cb1-0282-44a0-a29e-8e01c6ca282e',N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 08:46:09.8590674');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'56be18ae-df41-4741-a285-cb994d9332a6',N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 08:57:52.3564620'),
	 (N'56c365c0-80c9-48a8-8813-6981ed5783f5',N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 09:05:38.4553333'),
	 (N'57890069-3277-49b9-9e15-602a5bce8d22',N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 08:57:07.7437405'),
	 (N'586571fc-2d89-4df5-9faa-6fa91a123514',N'94e338c2-fc6c-45a9-b07e-e621ec938eb6',N'https://localhost:7121/images/product/25364213.jpeg',1,'2026-02-26 09:25:55.6459023'),
	 (N'5909c8e7-732e-4744-9586-e40ad0eb92c8',N'e865bcf6-af61-4e14-875d-1df6040cdace',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 08:47:15.9572707'),
	 (N'5e5cee3d-9583-46e3-b189-a0a429fa8bf2',N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'https://localhost:7121/images/product/1363833904.jpeg',0,'2026-02-26 08:39:57.0949805'),
	 (N'5ed179ba-7e5a-47cd-996b-d26f65161b45',N'278e36fc-dc3f-4f7c-b591-8dc98484215d',N'https://localhost:7121/images/product/1798175015.jpeg',1,'2026-02-26 09:32:23.7581864'),
	 (N'60c9bf72-77b9-4da1-925c-b686aa3641fe',N'c945145f-7bc1-4493-aa86-4e00981349a3',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 08:44:24.2530939'),
	 (N'62013021-29b7-42aa-8cf1-5ebef0102416',N'dbbc2bc4-028c-46a5-8e0c-7d15fb4f362d',N'https://localhost:7121/images/product/419192323.jpeg',0,'2026-02-26 09:42:01.3093850'),
	 (N'63014ffe-d264-455b-86d1-285423b5c739',N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 09:03:01.9179522');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'6460a3e7-c705-45a8-8368-30ae928dec3f',N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 09:07:14.1417488'),
	 (N'64cde642-7f83-42c5-b471-52acd908832a',N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'https://localhost:7121/images/product/1868566088.jpeg',0,'2026-02-26 08:38:02.1564292'),
	 (N'66fe150e-420b-4feb-9a3c-7d595a53bca7',N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 09:12:01.2840825'),
	 (N'67314418-2a07-4fde-95ad-283962dc4745',N'018a7d74-b334-4268-8999-341b7a89bed6',N'https://localhost:7121/images/product/398204993.jpeg',1,'2026-02-26 09:35:56.0692675'),
	 (N'6743ec27-d8e2-4cc4-ac9a-daeb85fecf56',N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 09:03:01.9170084'),
	 (N'6888dc37-ef84-4b7e-81dd-443f037a41e8',N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 09:10:21.2203717'),
	 (N'6912a0eb-fdbf-43e3-b85b-99a1eefe15ad',N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'https://localhost:7121/images/product/1648747165.jpeg',0,'2026-02-26 08:39:57.0925788'),
	 (N'692105e4-4da9-49d6-ba3f-2dd7f5dd0757',N'e337af94-093b-4594-b621-24d097991bb8',N'https://localhost:7121/images/product/365016232.jpeg',0,'2026-02-26 09:45:44.7098907'),
	 (N'694d4d25-c3e6-478a-85b4-8cc31a391cef',N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'https://localhost:7121/images/product/1868566088.jpeg',0,'2026-02-26 08:32:26.9642247'),
	 (N'69ed2288-6501-40ba-9707-5e994c9ecb6a',N'4d0d8171-af96-4960-a13d-7f184a432a62',N'https://localhost:7121/images/product/1618771266.jpeg',0,'2026-02-26 08:37:10.0569558');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'6b819932-9160-4066-b455-d6965c413aff',N'cefce310-fec8-4ae5-afd4-ec0d4f83d3fc',N'https://localhost:7121/images/product/1537392474.jpeg',0,'2026-02-26 09:31:01.1782308'),
	 (N'6c15f612-ae14-4f6a-a925-8e1f492058d7',N'2f60dd30-4fe1-4fe4-ab21-98831ba246b3',N'https://localhost:7121/images/product/1357004764.jpeg',1,'2026-02-26 09:24:44.3441231'),
	 (N'6c8e9fb6-c29f-4419-bf35-50870a1c4ecc',N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'https://localhost:7121/images/product/383981232.jpeg',0,'2026-02-26 08:34:19.2387287'),
	 (N'6feb5ff8-4881-4935-8e79-2949359cb5b1',N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 09:07:53.4830649'),
	 (N'70e09f67-ff2b-437d-9115-9292762f24d1',N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 08:50:46.9297547'),
	 (N'7140526b-a2cd-4456-980a-10f6606dd303',N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'https://localhost:7121/images/product/1395264656.jpeg',0,'2026-02-26 08:36:33.9509745'),
	 (N'71f3b566-ffa3-482f-ad46-32c9810514a2',N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'https://localhost:7121/images/product/2118360910.jpeg',0,'2026-02-26 08:38:02.1541347'),
	 (N'73bedffc-ba03-45f8-8550-9ac894a5129a',N'ee07f6d0-5b22-49ba-9a4c-ecad7d28e309',N'https://localhost:7121/images/product/1392371078.jpeg',0,'2026-02-26 09:25:16.6884236'),
	 (N'7404345d-dc21-472d-b38e-7e196d76a4a3',N'9345b995-0142-44a8-817d-7a292d9d9720',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 09:08:30.1076495'),
	 (N'79071737-67ae-4e35-b5b0-a0a00a8a8dd6',N'e647d21a-d03a-4822-83e8-0c394791674e',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 08:52:22.2404526');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'7e847b3d-e806-462b-81e2-a2b6832e046a',N'79a605c6-b56d-4ee6-be4c-e00b82e456b6',N'https://localhost:7121/images/product/1792655263.jpeg',0,'2026-02-26 09:37:23.6431748'),
	 (N'7fa4ff22-89be-463f-bc7f-ad916e8cb4c7',N'9345b995-0142-44a8-817d-7a292d9d9720',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 09:08:30.1029477'),
	 (N'7fc72da2-3a90-42ab-821c-6200f6b957d6',N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 08:57:52.3543530'),
	 (N'803e480c-a791-41be-b763-63819ac5fbf7',N'165f9138-5dff-4529-9e45-f85bd967e25d',N'https://localhost:7121/images/product/1020137047.jpeg',0,'2026-02-26 08:35:26.0008884'),
	 (N'81e21e45-0ae8-4367-9590-e7148d4206c2',N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 08:49:24.4306614'),
	 (N'8470274e-3213-425f-a6d1-8260257d53ef',N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 08:50:46.9284209'),
	 (N'8525d4bf-62c4-4b4e-8680-abfed9eb830e',N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 09:07:53.4821989'),
	 (N'85e0b301-ce2b-40f2-aa6a-73435554912e',N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'https://localhost:7121/images/product/1673125760.jpeg',0,'2026-02-26 08:34:19.2394931'),
	 (N'8702229b-2bb6-4029-bec2-df1e7f8a0835',N'165f9138-5dff-4529-9e45-f85bd967e25d',N'https://localhost:7121/images/product/1444935507.jpeg',1,'2026-02-26 08:35:25.9996453'),
	 (N'88827852-64b4-48a4-833b-918aedec69e0',N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 09:11:28.9449477');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'8cf84ee7-9109-437f-946d-72d29aae186b',N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 09:03:01.9159117'),
	 (N'8e8c0864-a91d-42a9-8737-db18c46bd5a7',N'4d0d8171-af96-4960-a13d-7f184a432a62',N'https://localhost:7121/images/product/1532109428.jpeg',1,'2026-02-26 08:37:10.0550502'),
	 (N'8faf221c-5d6e-4a16-a1a8-b744250bf85f',N'e865bcf6-af61-4e14-875d-1df6040cdace',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 08:47:15.9525837'),
	 (N'8fd2abca-aebd-47e9-aa47-f2005cb9073d',N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 09:11:28.9434514'),
	 (N'905e8d53-9883-4dd0-8098-3d34dd97c826',N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 09:04:25.8148939'),
	 (N'90862367-11e5-4665-a8d8-0350c7eb8461',N'dbbc2bc4-028c-46a5-8e0c-7d15fb4f362d',N'https://localhost:7121/images/product/1559912209.jpeg',0,'2026-02-26 09:42:01.3112044'),
	 (N'9092b9bf-9e1a-4b86-9c41-5c0b50f25d62',N'c35307d8-8775-40d6-b7bf-95af3e7d1731',N'https://localhost:7121/images/product/1270080297.jpeg',0,'2026-02-26 09:52:00.7891216'),
	 (N'93087fbd-96ca-4c5e-a2cc-062f988aa531',N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 08:53:26.4248670'),
	 (N'9478ff12-93ce-448e-9697-ab58f7cb0379',N'f595e797-5bde-4e90-b109-c8767ba1efa0',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 09:11:28.9443034'),
	 (N'950f79ce-ad9e-4497-a419-0fd731dd510d',N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'https://localhost:7121/images/product/812215371.jpeg',0,'2026-02-26 08:34:53.6038656');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'96762a32-fa84-4957-9619-a92b58ae282a',N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 08:46:09.8655849'),
	 (N'9688d78e-80e0-4ade-b35c-b4a166d0271d',N'cefce310-fec8-4ae5-afd4-ec0d4f83d3fc',N'https://localhost:7121/images/product/61885720.jpeg',0,'2026-02-26 09:31:01.1769226'),
	 (N'9878be99-938a-4745-b457-7783c1407884',N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 08:46:09.8580508'),
	 (N'98d6a597-fc23-494f-98ea-17f08181998d',N'79a605c6-b56d-4ee6-be4c-e00b82e456b6',N'https://localhost:7121/images/product/1893154691.jpeg',1,'2026-02-26 09:37:23.6294720'),
	 (N'98dcfaf2-91b0-418b-9b6c-6de57a899908',N'0443f578-4fb6-4459-95f7-edf7be5bc52d',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 08:49:24.4333349'),
	 (N'9909844e-6790-499a-978c-9069453c187a',N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'https://localhost:7121/images/product/1223993824.jpeg',0,'2026-02-26 08:38:02.1551090'),
	 (N'9dc61321-2053-4f63-95c5-f59a1c5c5fc0',N'e865bcf6-af61-4e14-875d-1df6040cdace',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 08:47:15.9543788'),
	 (N'9eeb9580-847b-4dc8-a8de-2b0df3b3cec8',N'c35307d8-8775-40d6-b7bf-95af3e7d1731',N'https://localhost:7121/images/product/1572319996.jpeg',0,'2026-02-26 09:52:00.7925386'),
	 (N'9fa78988-5a9b-48f5-818e-3b9f430f5846',N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'https://localhost:7121/images/product/183644029.jpeg',0,'2026-02-26 08:33:05.3443956'),
	 (N'a1844422-9cd5-4acd-b356-4193a02acedf',N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 09:12:01.2829451');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'a1bce7df-3837-48bc-8ff2-af3ad9294f21',N'165f9138-5dff-4529-9e45-f85bd967e25d',N'https://localhost:7121/images/product/1931375807.jpeg',0,'2026-02-26 08:35:26.0017604'),
	 (N'a525f198-63d1-438f-a9d4-75f8c6680cf3',N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 09:05:38.4543152'),
	 (N'a53603ad-9e0a-4843-845e-f74922c44029',N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 08:57:52.3531169'),
	 (N'a5a0ed2c-6aa6-4faa-9f99-77144fc4d9f5',N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 09:07:53.4838758'),
	 (N'a73d275b-7322-40ef-b6ab-c73e5d98f38f',N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 09:12:01.2849164'),
	 (N'a81bba85-0fc3-4cc9-8271-fac7a129aa69',N'4acac477-84ee-4fe2-816a-3be11cb1370f',N'https://localhost:7121/images/product/224206759.jpeg',0,'2026-02-26 09:41:23.0689146'),
	 (N'a9296ff8-aa0a-4a5f-87e0-119bc147fdbd',N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'https://localhost:7121/images/product/1416408118.jpeg',0,'2026-02-26 08:38:02.1558891'),
	 (N'a9d90542-4618-4ab9-b992-bbc1b2deeafd',N'94e338c2-fc6c-45a9-b07e-e621ec938eb6',N'https://localhost:7121/images/product/1341913370.jpeg',0,'2026-02-26 09:25:55.6497091'),
	 (N'aab8aa32-bc06-4aee-a74b-4c09a3cc16fc',N'2f60dd30-4fe1-4fe4-ab21-98831ba246b3',N'https://localhost:7121/images/product/1235075223.jpeg',0,'2026-02-26 09:24:44.3513201'),
	 (N'ab0f55b8-30eb-4c41-a307-5bd409615eb1',N'2f60dd30-4fe1-4fe4-ab21-98831ba246b3',N'https://localhost:7121/images/product/1801746374.jpeg',0,'2026-02-26 09:24:44.3497589');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'abba225c-8937-4e81-be3e-2f4e4376f862',N'1fd4434b-cc03-4ef6-bb62-4517d02c80a7',N'https://localhost:7121/images/product/1561851845.jpeg',1,'2026-02-26 08:38:02.1532079'),
	 (N'acc3b176-b898-49b7-9f91-1559b268e77d',N'56a46714-5bcb-4c59-825b-eeb4506d2759',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 09:12:01.2820107'),
	 (N'b1723ec3-f612-4b91-820f-ef2f879adde6',N'e647d21a-d03a-4822-83e8-0c394791674e',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 08:52:22.2412191'),
	 (N'b3462133-61d4-4410-9ae1-b37f56aa02cc',N'e647d21a-d03a-4822-83e8-0c394791674e',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 08:52:22.2418636'),
	 (N'b45be4e2-8a85-454d-ba3b-80f3450fab1c',N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 08:54:47.0090402'),
	 (N'b48bbd23-ae35-4e5a-b8f0-a8d090d1eac6',N'39d09f4a-d44c-4f65-aa65-69527854a22a',N'https://localhost:7121/images/product/308506456.jpeg',1,'2026-02-26 09:45:25.6348296'),
	 (N'b5262e4f-ea34-4d89-9bdf-e20dc3b27f60',N'94e338c2-fc6c-45a9-b07e-e621ec938eb6',N'https://localhost:7121/images/product/617946364.jpeg',0,'2026-02-26 09:25:55.6470434'),
	 (N'b5e61238-2278-4ad1-84c6-b8c9dd4a081d',N'72241bf3-b339-4682-a3f4-94a0e9334ce3',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 08:54:47.0109057'),
	 (N'b6284031-4350-41f0-93e6-150bf09fb8bc',N'cefce310-fec8-4ae5-afd4-ec0d4f83d3fc',N'https://localhost:7121/images/product/1593279373.jpeg',0,'2026-02-26 09:31:01.1753225'),
	 (N'b816c768-2828-4928-b300-62c48ac2c69c',N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'https://localhost:7121/images/product/383981232.jpeg',0,'2026-02-26 08:36:33.9551225');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'b87af647-4f29-458c-94b0-a485c28e269a',N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'https://localhost:7121/images/product/552432919.jpeg',0,'2026-02-26 08:34:19.2373863'),
	 (N'b9f7a1d2-b40c-441f-bb6f-ffbf0aa8fb7e',N'ffecf353-d208-4a61-b6a9-3b2d320f3f36',N'https://localhost:7121/images/product/1566913609.jpeg',1,'2026-02-26 09:31:34.0939448'),
	 (N'bc3326a5-c962-4b51-93c6-8e5e90eecd6e',N'9345b995-0142-44a8-817d-7a292d9d9720',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 09:08:30.1049593'),
	 (N'bccb2e72-0f6c-4b5b-96e2-444bb45da301',N'7dc1f14b-53b9-4325-8156-82179f1c85a5',N'https://localhost:7121/images/product/1931375807.jpeg',0,'2026-02-26 08:34:53.6026461'),
	 (N'be62cad9-50f8-4857-b5ec-036f6997bdff',N'c35307d8-8775-40d6-b7bf-95af3e7d1731',N'https://localhost:7121/images/product/1216141791.jpeg',1,'2026-02-26 09:52:00.7871507'),
	 (N'bede211a-761a-4c5e-aa77-96bf4a314e9b',N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 08:53:26.4306981'),
	 (N'bf097690-ba4c-447e-bb65-281f5d9c1389',N'165f9138-5dff-4529-9e45-f85bd967e25d',N'https://localhost:7121/images/product/1997379673.jpeg',0,'2026-02-26 08:35:26.0030909'),
	 (N'bff121a9-b50d-453b-98ce-0fdfe8f192b6',N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 09:05:38.4513924'),
	 (N'c0c407c4-de5b-4f37-a9db-f8a428d9de67',N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 09:03:01.9184911'),
	 (N'c16cc5da-d035-4502-b3ca-0dbb1aa72464',N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 08:53:26.4297164');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'c1b63e96-3681-4a4a-86bd-1ac930de08cd',N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 08:59:02.9383436'),
	 (N'c35b4d27-7ca7-4d30-a6e9-05e2b4c07926',N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 08:57:07.7425470'),
	 (N'c386ada4-3768-4b9f-8e91-36ac8c8fb862',N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'https://localhost:7121/images/product/1395264656.jpeg',0,'2026-02-26 08:34:19.2363111'),
	 (N'c40e3c0d-cb5e-4076-8924-dc932860cf02',N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'https://localhost:7121/images/product/1434570665.jpeg',1,'2026-02-26 08:39:57.0917089'),
	 (N'c4fe8b60-fb37-4ac9-9179-7f8deaf85c28',N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 09:07:14.1431353'),
	 (N'c5523ed5-ad02-49a7-9561-53bd21cf9a59',N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'https://localhost:7121/images/product/418858248.jpeg',0,'2026-02-26 09:05:38.4522740'),
	 (N'c59a47ee-e66c-4a5b-bace-534f7c8b1182',N'f9a2bfe2-9d91-4fb1-92e5-34c1f8bc04ea',N'https://localhost:7121/images/product/845672068.jpeg',0,'2026-02-26 08:39:57.0937432'),
	 (N'c647b945-ed61-4d39-b41f-720f357cf63d',N'4c47a6a2-ff6c-4493-9a9e-2903aaf4ee9f',N'https://localhost:7121/images/product/1618771266.jpeg',0,'2026-02-26 08:33:05.3424290'),
	 (N'c934ca65-2b16-48e8-91af-d8dad275d6e4',N'dbbc2bc4-028c-46a5-8e0c-7d15fb4f362d',N'https://localhost:7121/images/product/903897462.jpeg',1,'2026-02-26 09:42:01.3078345'),
	 (N'c986f666-114a-48ed-b32f-1c76f3666f75',N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 08:50:01.0183581');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'ca403ddc-ae2b-4db0-a1d0-d84e5a3d595c',N'e865bcf6-af61-4e14-875d-1df6040cdace',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 08:47:15.9535495'),
	 (N'ca6660af-28d0-4d52-9c7c-24309ceffcda',N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 08:57:07.7413033'),
	 (N'cadbe2dc-76d6-48ae-bd4e-c8ec05f8a738',N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 08:57:07.7451977'),
	 (N'ce91e055-6fe8-46a2-8cb4-ca9c9bc1106d',N'e647d21a-d03a-4822-83e8-0c394791674e',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 08:52:22.2366416'),
	 (N'cf5f442d-62d2-4688-a75a-5200af333d76',N'c945145f-7bc1-4493-aa86-4e00981349a3',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 08:44:24.2569986'),
	 (N'd0310ac3-91bb-4c6f-bed8-18f4c81fd4fd',N'7c4849da-be9e-4a1d-b9c6-327f89389827',N'https://localhost:7121/images/product/1173217141.jpeg',0,'2026-02-26 08:53:26.4261650'),
	 (N'd0420031-556b-48f8-b195-537568a4c494',N'7f059621-9ad6-4dc7-a51e-a9557420918c',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 08:50:01.0214323'),
	 (N'd1f5ecab-aeb9-4cbc-97d1-60817662980a',N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'https://localhost:7121/images/product/1223993824.jpeg',0,'2026-02-26 08:32:26.9618518'),
	 (N'd43c607b-2a91-418c-bc40-cff702a0447b',N'7a21b1b2-a383-4dab-8a8f-7708a7eb8d07',N'https://localhost:7121/images/product/552432919.jpeg',0,'2026-02-26 08:36:33.9542135'),
	 (N'd43ed21d-b7f6-414a-bda5-7a0c07820434',N'c945145f-7bc1-4493-aa86-4e00981349a3',N'https://localhost:7121/images/product/1321187019.jpeg',0,'2026-02-26 08:44:24.2548451');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'd4922435-a627-402d-ad6a-833c7ecae11b',N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 08:57:52.3558223'),
	 (N'd4a0ad5a-50e0-4201-bd9f-a1c9bcdd703b',N'051b18e4-349f-4476-a0da-4bfdf8fba804',N'https://localhost:7121/images/product/1169187685.jpeg',0,'2026-02-26 09:38:01.6457471'),
	 (N'd66755e9-e22d-437d-bfd7-ffcd63546dda',N'f3368dbd-288a-4ea2-b1d3-2ccc06fe8060',N'https://localhost:7121/images/product/1922679159.jpeg',0,'2026-02-26 08:57:07.7445599'),
	 (N'd7e5da63-45cb-427d-b5f4-9d6d4f3b9a90',N'e647d21a-d03a-4822-83e8-0c394791674e',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 08:52:22.2389580'),
	 (N'd83023f0-1c0c-4215-8ef5-7d7006b1e66b',N'10758b1a-0127-4f00-bb1d-88a133df0187',N'https://localhost:7121/images/product/1363833904.jpeg',0,'2026-02-26 08:30:35.7303216'),
	 (N'd902278f-c9dc-4703-83a9-4264dc1c2e10',N'c945145f-7bc1-4493-aa86-4e00981349a3',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 08:44:24.2540366'),
	 (N'dcc3b364-42ac-4eaa-8f52-f8ab2e1f6b15',N'ffecf353-d208-4a61-b6a9-3b2d320f3f36',N'https://localhost:7121/images/product/1438386675.jpeg',0,'2026-02-26 09:31:34.0997206'),
	 (N'dd084e81-56d0-4e54-80db-e087baf681de',N'65d8a94e-6d5b-4e4b-85a7-70ee99d3c181',N'https://localhost:7121/images/product/1781345450.jpeg',0,'2026-02-26 09:03:01.9200304'),
	 (N'ddbbd1ea-30f7-4fd7-a2f7-8d46307a9c33',N'3d1a93b9-f3df-409b-a78c-c3574b45998a',N'https://localhost:7121/images/product/1967942684.jpeg',1,'2026-02-26 08:59:02.9352803'),
	 (N'e24246bc-267a-48c4-93ec-fcfa707ff766',N'ee07f6d0-5b22-49ba-9a4c-ecad7d28e309',N'https://localhost:7121/images/product/1184162751.jpeg',0,'2026-02-26 09:25:16.6906090');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'e27092a0-e0fe-4ec7-866b-30e4dc670f25',N'051b18e4-349f-4476-a0da-4bfdf8fba804',N'https://localhost:7121/images/product/738421052.jpeg',0,'2026-02-26 09:38:01.6492735'),
	 (N'e2e21ab3-dd05-4949-9d6b-104ffa6f86a3',N'018a7d74-b334-4268-8999-341b7a89bed6',N'https://localhost:7121/images/product/393685330.jpeg',0,'2026-02-26 09:35:56.0724257'),
	 (N'e36e4010-6da7-4a3e-9193-a202d9db4d83',N'278e36fc-dc3f-4f7c-b591-8dc98484215d',N'https://localhost:7121/images/product/173372867.jpeg',0,'2026-02-26 09:32:23.7618429'),
	 (N'e5d67e4b-8619-4ebe-9417-58a69555fd60',N'10758b1a-0127-4f00-bb1d-88a133df0187',N'https://localhost:7121/images/product/1434570665.jpeg',1,'2026-02-26 08:30:35.7239195'),
	 (N'e60ace37-8cfa-467f-b47f-e8775d500972',N'd1cae663-c483-45e2-9580-8d724a9c1e92',N'https://localhost:7121/images/product/1037685474.jpeg',1,'2026-02-26 09:42:49.0765905'),
	 (N'e7cf23fd-4228-42a6-8c82-5bf957e74576',N'5caadb91-939d-49cb-85d5-a70f52514846',N'https://localhost:7121/images/product/1548357389.jpeg',0,'2026-02-26 09:51:40.2762085'),
	 (N'e862f4c0-5184-463f-a48b-cd0639d156b2',N'fedfa25a-cdf9-4707-b266-63f4c0a583c1',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 09:07:53.4854135'),
	 (N'ea12bb47-e538-43a1-aff3-aa2dc86ffc93',N'6cd35c14-83c9-4b5b-a6e2-24b9a8aaaccb',N'https://localhost:7121/images/product/283992595.jpeg',0,'2026-02-26 08:57:52.3570621'),
	 (N'eb3bf19c-2f8d-4097-9aae-814a148b229e',N'2f60dd30-4fe1-4fe4-ab21-98831ba246b3',N'https://localhost:7121/images/product/2054567230.jpeg',0,'2026-02-26 09:24:44.3467134'),
	 (N'eb8958cb-6e0a-4af0-a230-2341958febd1',N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 09:10:21.2229740');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'ecb054ee-94b9-4211-9bbc-6110134d5c79',N'165f9138-5dff-4529-9e45-f85bd967e25d',N'https://localhost:7121/images/product/812215371.jpeg',0,'2026-02-26 08:35:26.0024863'),
	 (N'ed93b2ed-b8e7-4621-a2c5-e145f10482f3',N'c35307d8-8775-40d6-b7bf-95af3e7d1731',N'https://localhost:7121/images/product/1511290557.jpeg',0,'2026-02-26 09:52:00.7912140'),
	 (N'ef953fd7-599d-4494-8524-e85a102f2a80',N'94b3acb9-6247-4621-9fe2-33ab7a015b7e',N'https://localhost:7121/images/product/518515043.jpeg',1,'2026-02-26 09:07:14.1398246'),
	 (N'f1dd8c4d-c2a3-46b3-a9c6-59b2b7019ecf',N'a4d8842d-218c-4452-87d5-69c1630ab33b',N'https://localhost:7121/images/product/2118360910.jpeg',0,'2026-02-26 08:32:26.9607373'),
	 (N'f37e1e91-6dc8-4c4b-aa0c-2e21c3553f41',N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'https://localhost:7121/images/product/139503515.jpeg',0,'2026-02-26 08:50:46.9321223'),
	 (N'f4753fe8-6cda-4aa9-b3a0-a3ccc4bfe257',N'5caadb91-939d-49cb-85d5-a70f52514846',N'https://localhost:7121/images/product/637405280.jpeg',0,'2026-02-26 09:51:40.2779789'),
	 (N'f50f8df4-8485-434f-a9a5-fdeee93b06cb',N'018a7d74-b334-4268-8999-341b7a89bed6',N'https://localhost:7121/images/product/1948586826.jpeg',0,'2026-02-26 09:35:56.0713712'),
	 (N'f537ea9b-59d3-44a4-b1b1-64b25e87adc6',N'39d09f4a-d44c-4f65-aa65-69527854a22a',N'https://localhost:7121/images/product/2116228808.jpeg',0,'2026-02-26 09:45:25.6374492'),
	 (N'f6d778c4-8e1f-4fae-a0a6-7909ad61bf6a',N'c945145f-7bc1-4493-aa86-4e00981349a3',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 08:44:24.2523829'),
	 (N'f752775a-3cd4-4c26-9299-f5a8c2f7c704',N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'https://localhost:7121/images/product/1206219074.jpeg',0,'2026-02-26 09:04:25.8144476');
INSERT INTO shopapp.dbo.variant_images (id,variant_id,image_url,is_main,created_at) VALUES
	 (N'f75815be-9227-49df-8384-c2387ccc0c6d',N'71d8f3f9-5234-4913-a1f7-09dd952f88aa',N'https://localhost:7121/images/product/1610035842.jpeg',0,'2026-02-26 08:50:46.9310687'),
	 (N'f9320f98-d8c5-4b71-b43c-3cb5e41144c6',N'7dd493c9-d58e-4303-819f-f4770ae38bf1',N'https://localhost:7121/images/product/1020805043.jpeg',1,'2026-02-26 08:34:19.2350444'),
	 (N'f9ec4ea4-eb53-404a-b0f0-2248e9f84e9b',N'923738b3-8ec8-4c9c-a905-9b25337b89d8',N'https://localhost:7121/images/product/1805762821.jpeg',0,'2026-02-26 08:46:09.8663133'),
	 (N'faf0442f-8357-4f4c-b9f1-ab0f5d476a01',N'278e36fc-dc3f-4f7c-b591-8dc98484215d',N'https://localhost:7121/images/product/910898862.jpeg',0,'2026-02-26 09:32:23.7607453'),
	 (N'fb3beaba-2b2e-45e6-b6a4-b69f3d60e9d1',N'f9d0f365-b762-4a4b-8a75-b6d966ba1d0c',N'https://localhost:7121/images/product/1457546301.jpeg',0,'2026-02-26 09:10:21.2215360'),
	 (N'fcbe44b9-0c85-4262-b3be-8a69e2f96c9c',N'fb893dc6-fddd-40a7-bd53-ff3e06ed2d83',N'https://localhost:7121/images/product/213053078.jpeg',0,'2026-02-26 09:05:38.4531775'),
	 (N'fde64cd9-1e85-44d5-9e96-500d0c2c8092',N'1fb3fc97-98b2-434b-b92c-5cecc0dc639e',N'https://localhost:7121/images/product/2122203324.jpeg',1,'2026-02-26 09:48:00.4762665'),
	 (N'fee3b3f0-cc10-4c1e-9c81-f3d712eb6f51',N'018a7d74-b334-4268-8999-341b7a89bed6',N'https://localhost:7121/images/product/28467799.jpeg',0,'2026-02-26 09:35:56.0737353'),
	 (N'fefa0327-5272-4e3d-a359-78420ebf14aa',N'01252712-436f-40d5-81bd-75ae4bbe2e66',N'https://localhost:7121/images/product/1621258569.jpeg',1,'2026-02-26 09:04:25.8110193');
