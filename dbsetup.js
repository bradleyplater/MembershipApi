
let res = [
  db.users.drop(),
  db.users.createIndex({ Name: 1 }),
  db.users.createIndex({ Balance: 1 }),
  db.users.insert({ _id: 123, Name : 'Bradley', Balance : 22.33 })
]

printjson(res)

