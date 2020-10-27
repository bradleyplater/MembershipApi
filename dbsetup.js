
let res = [
  db.users.drop(),
  db.users.createIndex({ Name: 1 }),
  db.users.createIndex({ Balance: 1 }),
  db.users.insert({ _id: 123, Name : 'Bradley', Balance : 22.33 }),
  db.users.insert({ _id: 432, Name : 'John', Balance : 3.21 }),
  db.users.insert({ _id: 553, Name : 'Sam', Balance : 44.22 })
]

printjson(res)

