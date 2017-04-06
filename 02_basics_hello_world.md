# F# Basics

### Syntax
Just like Python, F# syntax  is based on **indentation**. But compared to Python, it might seem having more words for code than neccesary length. 

### Defalut Immutable
As I previously said that in the last session, 'Functional programming avoids changing-state and mutable data.' In F#, all variables are **immutable** by defalut. Like constant! Once you assign a value inside a variable, you cannot change(re-assign) a value. What should we do to make an variable mutable then? Well, we will see that later.

### Type Inference
F# is very powerful in terms of **type inference**. What's type inference? 
> Type inference refers to the automatic deduction of the data type of an expression in a programming language. It is a feature present in some strongly statically typed languages. It is often characteristic of functional programming languages in general. The ability to infer types automatically makes many programming tasks easier, leaving the programmer free to omit type annotations while still permitting type checking.

This is from [Wikipedia](https://en.wikipedia.org/wiki/Type_inference). So, long story short, you don't really need to define the type of variables while you are programming (Think about Python. While in Java, every single variable has to be typed right?) But at the same time they are very strongly typed. What? Yeah, this is because of its immutable nature. As I told you, variables are immutable by default. So, once it has a value, let's say 3.0, then this variable's type is strictly float although the user did not specifically say "you have to be a float!" (i.e. Instead of float a = 3.0 user just can type a = 3.0) 

Ok, then shall we jump to actual programming?

#### 1) How to name the module in F#
In Java, we have to give a name to the source file and it is also encourage to name the package inside of java file. We use a keyword, **package** to specify the package and use **public class** to name the java class. This java class has to be the same as the source file name. 
In F#, we use a keyword **module** to name the file. On the top of the file, type:
```
module Simple
```
Then, you just named the module that you are working on.

#### 2) How to use 'Namespace' / How to open 'modules' in F#
We often use other modules from other files to use some methods defined in that modules. In Python, we use a keyword **from** and **import** to open the module that we want to refer to. To open the other modules in F#, we use **open**. Usage is like below:
```
open System
```
Now you can use methods defined in System.

#### 3) How to print "Hello World!" in F#
Ok, now we are ready to make a very first step to learn a new language, print out "Hello World!"
(It is very important to do this although some of you may think it is tedious :disappointed:)
Let's do it.

First of all, we use **printf** to print something out. Indeed, F# printf is inspired from C. Since I am not really familiar with C, I will not talk about that but I will explain how to use it. Here is an example.
```
printf "%d" 10
```
This means **Print out the number which is an integer but not double and its value is 10**
So, the output of this will be:
```
10
```
This looks similar to **String_with_{}.format()** in Python. All you need to write is **printf then the type of value that you try to print with double quotes and then put either name of variable containing the value or the actual value**.

Note that double quotes make the thing to print out to type of String. For example, if you try to do like this:
```
printf 10
```
It will give you an error since you cannot print out non-string type straight away. You have to type "%d" 10.

There are a few different types you need to specify. Here's the list
- "%d" : integers not doubles
- "%s" : strings
- "%i" : integers
- "%f" : floats
- "%b" : booleans
- "%A" : **anything!**

For "%A", you do not need to specify the type of value. So, it will be quite handy if you just want to know the value inside of variable that you do not know what type is inside of it. 

What if you give a wrong type after printf? Well, once you run it the F# compiler will immediately say 
> The type 'you gave' is not compatible with 'the actual type of value to print out'

So, you need to give a correct type. (Again, if you are not sure about the type, just use "%A" if you don't want to be interrupted by the compiler)

You can also print out multiple stuff in one line. Like this:
```
printf "A string: %s. An int: %i. A float: %f. A bool: %b" "hello" 42 3.14 true
```
You see that "A string: %s. An int: %i. A float: %f. A bool: %b" part is combination of string and lots of "%x"s. By using this, you can **format** the string to print out. And notice that you just list things you want to print out after that format part. (i.e. "hello" 42 3.14 true)

"hello" is string, 42 is integer, 3.14 is float and true is boolean. So, they will be put into corresponding "%x". This will give you the output like this:
```
A string: hello. An int: 42. A float: 3.140000. A bool: true
```
You see that %s is replaced with "hello", %i with 42 and so on.

What if you try to change the order of values like this?
```
printfn "A string: %s. An int: %i. A float: %f. A bool: %b" "hello" 42 true 3.14
```
I swapped true and 3.14. The answer is.. The F# compiler will tell you 
> The type 'bool' is not compatible with any of the types float,float32,decimal, arising from the use of a printf-style format string. This expression was expected to have type bool but here has type float.

Yeah, so the order of values should respect to the order of types specified in double quotes.

Ok, finally we can print out "Hello world!"
```
printf "Hello world!"
printf "%s" "Hello world!"
```
Both will give you the same result.
```
Hello world!
```
Ok, so this is the end of this session. But before you go, here is a bit that I have missed.You might have noticed that I have used **printfn** instead of printn. What's the difference between printf and printfn? Well, it is simple. **printfn** is printf with a new line at the end. But in LINQ pad, printf also gives a new line but printfn gives a new line and extra gap between two lines. But it is supposed to be shown in the same line if you have used printf.

Alright! See you in next session! :stuck_out_tongue_winking_eye:
