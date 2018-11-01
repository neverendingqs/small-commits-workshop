<!-- Docs: https://github.com/gnab/remark/wiki -->
<!-- Example: https://github.com/gnab/remark/blob/gh-pages/index.html -->

class: center, middle

# Small Commits in Practice: A Hands-on Workshop

Carl Pacey and Mark Tse

---

# Introduction

---

# Agenda

* Goals
* Exercise 1: Breaking up a pull request (~45 minutes)
* Exercise 2: Plan implementing a feature using small commits (~45 minutes)

---

# Goals

---

# Exercise 1: Breaking up a pull request

---

# Exercise 2: Let's add a new feature

* You're hopefully familiar with Users after Exercise #1.
* You may have noticed that the app already supports `/fizzbuzz/{number}`.
* Now we're going to expand the `/fizzbuzz` functionality to include user information.

---

# Exercise 2: Best route ever

We want to add the following route:

`/fizzbuzz/{number}/users/{userId}`

This route will return a modified FizzBuzz:

1. Instead of "Fizz", this route will use the user's UserName.
1. Instead of "Buzz", this route will use a new user property, BuzzWord.

---

# Exercise 2: Specification by Example

```http
GET /users/1045
```

```json
{
  "id": 1045,
  "userName": "cpacey",
  "isActive": true,
  "buzzWord": "isawesome"
}
```

| `GET` |      Result      |
|:----------|:-------------|
| `/fizzbuzz/14/users/1045` |  `29` |
| `/fizzbuzz/30/users/1045` | `cpacey` |
| `/fizzbuzz/50/users/1045` | `isawesome` |
| `/fizzbuzz/75/users/1045` | `cpaceyisawesome` |

---

# Closing
