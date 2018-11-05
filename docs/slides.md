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

Get some practice breaking up PRs:

1. _After_ the code is written
1. _Before_ the code is written

---

# Some Techniques

* Add new tests to existing code
  * This is safer if you don't change production code
* Refactor existing production code
  * This is afer if you don't change test code or functionality
* Add a new class, method, or property
  * Test it, but don't use it
* Functional changes
  * This is safer if the only test changes are for the new/altered functionality

---

# Exercise 1: Walkthrough

* Branch: `exercise1/bigpr`
* Pull request: https://github.com/neverendingqs/small-commits-workshop/pull/27

---

# Exercise 1: Breaking up a pull request

Tasks:
1. Break up the commit into smaller commits
   * Branch: `exercise1/bigpr`
   * Pull request:
     https://github.com/neverendingqs/small-commits-workshop/pull/27
1. For each commit
    * Create a pull request onto `<user>:master` (the `master` branch in your
      fork)
    * Have your partner review the pull request (either in-person or via GitHub)
    * Merge the pull request
1. Continue until `<user>:master` is functionally similar to `exercise1/bigpr`

*Note: you first need to [add your partner to your
fork](https://help.github.com/articles/inviting-collaborators-to-a-personal-repository/)
before you can add them as pull request reviewers*

---

# Exercise 2: Let's add a new feature

* You're hopefully familiar with Users after Exercise #1.
* Now we're going to expand some functionality to include user information.

---

# Exercise 2: FizzBuzz

FizzBuzz is a famous interview question:

> Write a program that prints the numbers from 1 to 100. But for multiples of three print "Fizz" instead of the number and for the multiples of five print "Buzz". For numbers which are multiples of both three and five print "FizzBuzz".

https://blog.codinghorror.com/why-cant-programmers-program/

---

# Exercise 2: Existing Functionality

You may have noticed that the app already supports `/fizzbuzz/{number}`.

```
GET /fizzbuzz/14: 14
GET /fizzbuzz/15: FizzBuzz
GET /fizzbuzz/16: 16
GET /fizzbuzz/17: 17
GET /fizzbuzz/18: Fizz
GET /fizzbuzz/19: 19
GET /fizzbuzz/20: Buzz
GET /fizzbuzz/21: Fizz
GET /fizzbuzz/22: 22
```

---

# Exercise 2: New Functionality

We want to add the following route:

```
/fizzbuzz/{number}/users/{userId}
```

This route will return a modified FizzBuzz:

1. Instead of "Fizz", this route will use the user's UserName.
1. Instead of "Buzz", this route will use a new user property, BuzzWord.

---

# Exercise 2: Example

```json
GET /users/1045
{
  "id": 1045,
  "userName": "cpacey",
  "isActive": true,
  "buzzWord": "isawesome"
}
```

```json
GET /fizzbuzz/14/users/1045: 14
GET /fizzbuzz/15/users/1045: cpaceyisawesome
GET /fizzbuzz/16/users/1045: 16
GET /fizzbuzz/17/users/1045: 17
GET /fizzbuzz/18/users/1045: cpacey
GET /fizzbuzz/19/users/1045: 19
GET /fizzbuzz/20/users/1045: isawesome
GET /fizzbuzz/21/users/1045: cpacey
GET /fizzbuzz/22/users/1045: 22
```

---

# Exercise 2: Any questions so far?

---

# Exercise 2: The design

To simplify things, here's the design we're going to go with:

1. `FizzBuzzController` will get a new route handler method which...
1. looks up the user, and...
1. calls `IFizzBuzzService` with the appropriate information

---

# Exercise 2: What we're going to do

1. Plan how you'll build the PRs (5-10 mins)
1. Code it up (Remaining Time)

---

name: tablify

# Exercise 2: Planning

Write down your plan for implementing this in 2-5 separate PRs.

For exercise 1, this could be:

| Example #1 | Example #2 |
|:-|:-|
| 1. Add User.IsActive<br>&nbsp;&nbsp;&nbsp;&nbsp;(+ update tests for 1 route)<br>2. Add index on User.Id<br>3. Add GET route<br>&nbsp;&nbsp;&nbsp;&nbsp;(+ new tests)<br>4. Add POST route<br>&nbsp;&nbsp;&nbsp;&nbsp;(+ new tests) | 1. Add index on User.Id<br>2. Add GET and POST routes<br>&nbsp;&nbsp;&nbsp;&nbsp;(+ new tests) with tests<br>3. Add User.IsActive<br>&nbsp;&nbsp;&nbsp;&nbsp;(+ update tests for 3 routes)<br><br><br> |

---

# Exercise 2: Code it up

Code up your plan, in order.

---

# Exercise 2: Aftermath

How did that work out for you?

---

# Appendix: How can I split this up?

Questions to ask yourself (in no particular order):

* Can I improve test coverage by itself?
* Can I refactor the existing code to make things easier?
* Can I add a new class, method, or property by itself?
* Can I make a small, possibly ugly change by itself, and the refactor later?

---

# Appendix: How do I know if I'm on the right track?

You're on the right track if:

* The PR has a single responsibility.
* The PR is easy to review.
* The PR can be shipped to production.
* The PR is low risk.

---

# Closing
