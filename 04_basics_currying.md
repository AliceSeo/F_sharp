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

Each function (add_integers and its output function) takes exactly one integer as a parameter although it seems like only one function, add_integers is taking 2 parameters at the same time. As I told you, F# respects mathematical rules quite strictly.  :smirk: Here's more mathy explanation with code.
```
let add_integers x y = x + y
// add_integers: int -> int -> int
// add_integers: int -> (int -> int)

printfn "add_integers 1 2 : %d" (add_integers 1 2)
```
The second line **add_integers: int -> int -> int** shows the signature of the function. i.e. the domain and the range of the function. 

The first int (add_integers: **int** -> int -> int) represents the first parameter of the function, in this case, 1. 

The second int (add_integers: int -> **int** -> int) represents the second parameter of the function, in this case, 2.

The last int (add_integers: int -> int -> **int**) indicates the type of output, range. 

Hence, the third line of the code, **add_integers: int -> (int -> int)** shows the entire structure of this function. add_integers takes one integer, 1, and produces a function, shown as a bracket, which takes one integer, 2, and returns integer value after the calculation.

So, the invocation (add_integers 1 2) can also be written as ((add_integers 1) 2).


#### 2) What's the partial evaluation?

Yeah that was quite complicated enough. But I guess maybe this section will show you why do we need to understand **currying** because currying is closely related to the **partial evaluation**.

What is the partial evaluation? 

It is to fix a value into its first parameter of a function which looks like taking more than one parameters. Let's look at the example:
```
let add_integers x y = x + y

let add_integer_to_3 = add_integers 3
printfn "add_integer_to_3 7: %d" (add_integer_to_3 7)
printfn "add_integer_to_3 1: %d" (add_integer_to_3 1)
```
Ok, although it looks like taking 2 parameters, I told you add_integers only takes one parameter and it returns a function, right? The second line of the code shows that. **add_integers takes the parameter, value of 3, and returns a function named add_integer_to_3**. This is just a same effect as you assign a value 3 to the first parameter, x. 

Hence, if you try to print out the third line and the forth line, you will get this:
```
add_integer_to_3 7: 10
add_integer_to_3 1: 4
```
You might think that add_integer_to_3 is just a **normal** function which takes an integer and returns an integer. Yeah that's right? It is a **low-level** function which takes one parameter and returns one output. :smiley:

This is quite handy since you do not need to build a every single function to calculate different values addition. For example, if you need to calculate a series of values which are sum of input and 1, sum of input and 2, sum of input and 3, sum of input and 4. Are you going to write 4 functions to solve this? No. You just need to use add_integers and loop those values (1,2,3,4) through the function. Efficient!

#### 3) Other examples
Now we will look at some other examples of other types of inputs and outputs.
```
let add_floats (x:float) (y:float) : float = x + y

printfn "add_floats 1.0 2.0: %f" (add_floats 1.0 2.0)
```
Note: One thing I need to mention here before I keep on going is: Arithmetic operations (such as +) are defaulted as int operations. If you want to make it possible to calculate other types, you have to declare it explicitly as I have shown in the last session, [03_basics_others](https://github.com/AliceSeo/F_sharp/blob/master/03_basics_others.md) That's why I have explicitly declared them float, float and float.


