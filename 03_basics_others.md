# F# Basics

In this session, we will learn other basic practical stuffs for F# programming. 

#### 1) How to write comments in F#
In Java, we are using // for single line comment and /*  */ for multiple line comment. In F#, we are using the same thing for the single line comment, but for multiple lines, we use (\*  \*). Here's example.
```
(* This can be a multi-line comment *)
(* Like 
this! *)
// and this is a single line comment
```
As you know, those comments are ignored by compiler. So, you can put some explanation about the code if your code is too complicated to understand or to clarify things.

#### 2) How to specify the entry point of the program in F#
In Java, we have **public static void main(String[] args) { ... }** which is the starting point of the program. If you compile that java file and run the corresponding class file, it will run that main method. While in Python, we do not have a special starting point. Interpreter will read lines of code from the top to bottom and execute it line by line. In F#, we use this:
```
[<EntryPoint>]
```
Well, it is really obvious sign for entry point, right? :joy: 
So, the overall structure of the F# file will look like this:
```
module Example // Name the module that you are working on 
open System // Open the Namespace if you want to use other modules or methods

(* Some function definitions should come here
...
...
*)

[<EntryPoint>] // This is the main entry point of the program

(* Put things that you want to run *)
```

#### 3) How to assign a value in a variable / How to define a function
In F#, we use a special keyword **let** whenever we make a new variable and assign a value in it or when we define a function. Hmm.. As I told you in the last session, all variables in F# are immutable by default. Once a value is assigned in a variable, you cannot change it. So, maybe the name 'variable' is not a proper word to call it. 

Anyway, this is how we assign a value in a variable.
```
let x = 3
```
Note that you do not need to specify its type. In the last session, we saw that F# is very powerful in terms of type inference. But if you want to type it, you can do it explicitly.
```
let x:int = 3
```
In java, we would do **int x = 3;** but in F# it is other way around. You put **let** then, name of the variable, then its type with :. Then you put a value in it. But why would you do this? F#'s advantage is strong type inference. You don't really need to do this.

Let's try to bind values and then print them.
```
let x1 = 10
let int:x2 = 10
printfn "%d %d" x1 x2
```
This will give you
```
10 10
```
Now let's try to make a simple unary function. We will make a function named **increment** which takes one integer parameter and returns an interger which is same as given parameter but incremented by 1. We will see the example without typing first.
```
let increment x = x + 1
```
That's it. :anguished:

So, the syntax is like this. **let name_of_the_funtion parameter = return_value**

In this example, the important point is that its domain is **int** and also its range is **int**. How do we know? F# inferred it. How???
Well, increment function takes one unknown type (we say 'generic type') variable and add 1 to it and returns it. Notice, 1 is integer. So, F# infers that x will be an integer and addition between integers will return another integer. Thus its domain(value of x) is int and also its range(returned output) is also int.

To use this function, we simply follow the instruction given in definition **increment x**
```
let increment x = x + 1
printfn "%d" (increment 1)
```
Note that we need () to cover **increment 1** otherwise printfn will think there are 2 parameters are given. Anyway, It will give 
```
2
```
What if we try to do this?
```
let increment x = x + 1
printfn "%f" (increment 2.0)
```
The compiler will say
> The type 'int' is not compatible with any of the types float,float32,decimal

This is because F# has thought that increment will have int as its domain and range due to existence of 1 in its definition. So, if you try to use float, it does not match with its domain and so it gives an error.

To make it possible, you need to make 1 as a float. (i.e. 1.0) So, F# compiler will think both its domain and its range will be float.

You can explicitly type the domain and the range of that function like this:
```
let increment (x:int):int = x + 1
```
Within the parenthesis, we specify the type of the parameter, x and right after the closing bracket, we specify the type of output with :. But even if you do this you cannot mismatch the domain and its range like this:
```
let increment(x:int):float = x + 1.0
printfn "%f" (increment 3)
```
Although in here, I declare that parameter will be an integer and its output will be a float because I will add floating point number 1.0, it gives me an error like this:
> The type 'float' does not match the type 'int' 

As I told you in the last session, it does not do automatic conversions.

#### 4) How to make a variable mutable
In F#, all variables are immutable by default. But there is a special keyword which turns a variable into mutable variable. That's **mutable** :joy:. Put that mutable after **let**.

But unlike other programming languages, you have to use different assignment operator. It's not =. Look at the below example.
```
let mutable a = 3 // Initial value is 3
printfn "a was: %d" a
a <- 10 // Re-assignment
printfn "Now a is: %d" a
```
Initial assignment uses = just like other programming languages. But for re-assignment, we have to use ** <- ** like mathematical statement. As you know, we use = to show equality not to indicate a value is inside of it. We use <-. You can also use this to do some calculation with refering to the same variable. (i.e. In Java or Python, you do x += 1 or x = x + 1 to increment x. But in F# we do x <- x + 1).

The above example will give the output like this:
```
a was: 3

Now a is: 10

```
What if you use = for re-assignment?
```
let mutable a = 1
a = 10 // Wrong, but try
```
As I said, = is used to show equality. So, a = 10 means a is equal to 10. However, the value inside a is initially 1. So, 1 = 10 will give a boolean, **false**. Which is what we did not expected.

#### 5) How to define a recursive function / How to use match with keywords
In Python or Java, you do not need to explicitly say that a function is recursive if you want to make a function as a recursive function. But in F#, you need to declare that the function is going to be **recursive** if you want to make it so. You need to use a key word **rec** right after **let** like this:
```
let rec fibonacci x = 
	match x with 
	| 0 -> 1
	| 1 -> 1
	| _ -> fibonacci (x - 1) + fibonacci (x - 2)
	
printf "fibonacci 5: %A" (fibonacci 5)
```
Yeah this is one of the famous examples of recursive function, Fibonacci sequence. As you can see it is declared as **rec**. There are some points that I want to explain in this code. 

**match x with |**

This is a smiliar to ** switch (x): case ** in Java. Let's have a closer look one bit by bit. **match x with** means "Look at the value inside x and see if it matches one of cases that I am going to list below". And there are some statements with **|** (pipe - or OR). 

** | 0 -> 1 ** means "if x is 0, then return 1". Same as the next line. 

** | 1 -> 1 ** means "if x is 1, then return 1".

And then you will see that weird **underscore, _**

This underscore means **wildcard**. So, **| _ -> fibonacci (x - 1) + fibonacci (x - 2)** means "if x is the others (not 0 nor 1), then call fibonacci function recursively calculate the value, and return that value.

You can use these features (rec, wildcard and match & with keywords) to implement many other things :smile:

Yeah, that's it for this session. Thank you! and see you in the next session :wink::v:
