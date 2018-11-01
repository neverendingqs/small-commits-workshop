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
* Quick refresher on techniques
* Exercise 1: Breaking up a pull request (~45 minutes)
* Break (~10 minutes)
* Exercise 2: Plan implementing a feature using small commits (~45 minutes)

---

# Goals

---

# Techniques

* Add a new class, method, property, etc
  * Test it, but don't use it
* Add new tests to existing code
* Refactor existing code
  * Specifically to make your next change easier, safer, or smaller
  * Try to limit or isolate test changes
  * Try to avoid (or isolate) functional changes
* Functional changes are smaller after you make the above non-functional changes first

---

# Exercise 1: Breaking up a pull request

---

# Exercise 2: Let's add a new feature

* You're hopefully familiar with Users after Exercise #1.
* You may have noticed that the app already supports `/fizzbuzz/{number}`.
* Now we're going to expand the `/fizzbuzz` functionality to include user information.

---

# Exercise 2: Wait, WTF is FizzBuzz?

[content goes here]

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
| `/fizzbuzz/2/users/1045` | `2` |
| `/fizzbuzz/6/users/1045` | `cpacey` |
| `/fizzbuzz/10/users/1045` | `isawesome` |
| `/fizzbuzz/15/users/1045` | `cpaceyisawesome` |

---

# Closing
