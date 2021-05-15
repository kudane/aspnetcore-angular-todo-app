Todo.Core
# Overview
  Define a business logic or usecases
  Define a I/O Abilities to [Infrastructure]
  If using [Business Object] then create per entity or table

Todo.Infrastructure
# Overview
  Implementation interfaces Todo.Core

Todo Aplication Spec
# Feature
- Add Todo
- Delete Todo
- Clear Todo
- Make Complete

#In Progress
- [x] 1. Signin ใช้ CanActive แล้วไม่แสดงหน้า html (ปัญหาเกิดจากไม่ได้ทำข้อ 2)
- [x] 2. จัดการเรื่อง User inmemory รีเฟรช แล้วข้อมูลหาย
- [x] 3. แสดง menu เมื่อ authen แล้วเท่านั้น
- [ ] 4. refactor code หรือ ตรวจโค้ดที่ copy มาใช้ หรือ โค้ดที่ไม่จำเป็นออก
- [ ] 5. จัดโครงสร้าง todo เช่น model, resolver