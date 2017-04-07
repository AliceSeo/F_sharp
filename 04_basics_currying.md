# F# Basics - Currying
In this session, you will learn about **Currying**.  (Currying? :curry::speech_balloon: ...sorry:joy:)

#### 1) What's Currying?
> In mathematics and computer science, **currying is the technique of translating the evaluation of a function that takes multiple arguments (or a tuple of arguments) into evaluating a sequence of functions, each with a single argument.** Currying is related to, but not the same as, partial application.
Currying is useful in both practical and theoretical settings. In functional programming languages, and many others, it provides a way of automatically managing how arguments are passed to functions and exceptions. In theoretical computer science, it provides a way to study functions with multiple arguments in simpler theoretical models which provide only one argument. The most general setting for the strict notion of currying and uncurrying is in the closed monoidal categories; this is interesting because it underpins a vast generalization of the Curry–Howard correspondence of proofs and programs to a correspondence with many other structures, including quantum mechanics, cobordisms and string theory. It was introduced by Gottlob Frege,developed by Moses Schönfinkel, and further developed by Haskell Curry....

This is from [Wikipedia](https://en.wikipedia.org/wiki/Currying).

So, long story short, **currying is when you break down a function that takes multiple arguments into a series of functions that take part of the arguments**.

In mathematics, we try to allow a function to only have one parameter in order to make it simpler and easy to understand. F# is a functional programming language which follows this rule quite strictly. Then how is it possible that an F# function can have more than one parameter? Below is an example:
```
let add_integers x y = x + y

printfn "add_integers 1 2 : %d" (add_integers 1 2)
```
You might say, "See? this function, add_integers takes 2 parameters, x and y, right?" But indeed, this function, add_integers is a high-order function, also known as functional function. [Wikipedia](https://en.wikipedia.org/wiki/Higher-order_function) says:

> In mathematics and computer science, a higher-order function (also functional, functional form or functor) is a function that does at least one of the following 1) takes one or more functions as arguments (i.e., procedural parameters), 2) returns a function as its result
    
So functions which either take a function as its input or return a function as its output are called **high-order functions**. This is what actually happens behind the scene. In fact, add_integers function takes **ONE** integer parameter and returns **another function** which takes **ONE** more parameter.
