
let res = [
  db.users.drop(),
  db.users.createIndex({ Name: 1 }),
  db.users.createIndex({ Balance: 1 }),
  db.users.insert({ _id: 123, Name : 'Bradley', Balance : 22.33 }),
  db.users.insert({ _id: 432, Name : 'John', Balance : 3.21 }),
  db.users.insert({ _id: 553, Name : 'Sam', Balance : 44.22 }),
  db.users.insert({ _id: 532, Name : 'Timmy', Balance : 1.00 }),
  db.users.insert({ _id: 444, Name : 'Aaron', Balance : 6.77 }),
  db.users.insert({ _id: 121, Name : 'Sam', Balance : 50.00 }),
  db.users.insert({ _id: 600, Name : 'Liam', Balance : 3.50 }),
  db.users.insert({ _id: 601, Name : 'George', Balance : 10.00 }),
  db.users.insert({ _id: 602, Name : 'Becca', Balance : 154.33 })
]

printjson(res)

