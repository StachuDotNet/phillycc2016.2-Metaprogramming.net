- title : Going Meta with .NET
- description : Metaprogramming in the .NET World
- author : Stachu Korick
- theme : night
- transition : default

***

## Going Meta with .NET

[This slide intended to avoid distracting us from actual content]

- Who is this guy?
    - Stachu Korick. I won't bore you with my life story.
    - If you want to chat, email me or grab drinks at the after-party.
- Can I ask questions?
    - Yes, but wait for an appropriate time.
- How much of this consists of slides?
    - 40%? Heavy in the beginning, light near the end.
- Should I frantically take pictures of the screen?
    - No. Slides/code available at [stachu.net/metaprogramming]

***

Metaprogramming is weird.

### Goals

- describe metaprogramming
- discuss available technologies
- dive into examples in T4, CodeDOM, Reflection, etc.
- provide intuition for metaprogramming in business environment

***

### Talk Structure

- [15] Introduction to Metaprogramming and a Primer on Expression Trees
- [15] In-Depth: Code-Consuming Metaprogramming
    - Reflection
- [35] In-Depth: Code-Producing Metaprogramming
    - T4
    - CodeDOM
    - Reflection.Emit
    - Expression Manipulation
- [10] Outro

***

### Defining Metaprogramming
#### Textbook definition:

Metaprogramming is the writing of computer programs with the ability to treat programs as their data.

It means that a program could be designed to read, generate, analyse or transform other programs, and even modify itself while running.

---

### Defining Metaprogramming
#### My definition:

My definition:
Code that reads or writes code [1]

[1] or code-like things.


---

## Relevant Buzzwords

- Reflection
- Code Generation
- T4
- CodeDOM
- Roslyn
- DSLs
- Embedded Languages
- Generative Systems
- Direct Output
- Templates
- Metadata-driven
- AOP
- Application Scripting
- Dynamic Runtime

***

## Code-Consuming vs Code-Producing Metaprogramming

---

### Code-Consuming Metaprogramming

- Tests
- ORMs (Code-first EF)

---

### Code-Producing Metaprogramming

- DB-first EF
- JSON/XML -> C# Classes tool
- LinqPad

***

## The ".NET Process"

Why talk about this?

- to appreciate the history and focus of Metaprogramming in .NET
- to visualize many technologies via code graphs and expression trees

---

### The ".NET Process" in a Nutshell

Mentally architect

-> Write source code (C#, VB, etc.)

-> Utilize the .NET SDK to turn our source code into IL (.dll, .exe)

-> Transform IL into machine code via the CLR using JIT compiler

-> Execute on client

---

### OK... How is this relevant to Metaprogramming?

## Metaprogramming executes in the seams!
















***

## Code-Consuming Metaprogramming
### .NET Reflection

---

### What is Reflection?

Definition: Inspecting the metadata and compiled code inside of an assembly.

- Querying our code as if it were data (because it is!)
- Been around since .NET 1.1
- Powers much of the 'magic stuff' you wonder about in the .NET world

---

## Demo: Recreating part of NancyFx

---

### Reflection in the Wild

- Class Definition
- Object Browser
- ILDASM
- Decompilers
- Mocking frameworks
- Testing frameworks
- Dependency Injection Frameworks
- Entity Framework
- Most "magical" things




















***

## Code-Producing Metaprogramming

- T4
- CodeDOM
- Reflection.Emit
- Expression Manipulation

***

### Text Template Transformation Toolkit


    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ output extension=".txt" #>

    Hello World,

    The time is now <#= DateTime.Now.ToShortTimeString() #>

    <#

        for (int i = 0; i < 10; i++) {
            WriteLine(i.ToString());
        }
        
    #>


Directives, Text Blocks, Control Logic

---

### Types of T4 Templates

- Design-Time Templates
    - Used to generate code/files to be consumed during design time
    - Can use CodeDOM
    - Can interact with model designers
- Run-Time Templates
    - Usable by the rest of your code
    - Parameterized
    - Can be executed outside of Visual Studio

---

### When is T4 Useful?

- Code Generation
- Document Generation

---

### T4 Demos

- Hello World
- Pregenerated Templates
- Nested Templates
- Errors/Warnings
- Generating POCOs from a database

---

### You Have Benefited from T4!

- Razor generation with ASP.NET MVC
- (depracated) Database-First Entity Framework

---

### Other Usages of T4

- Mailer
    - Doesn't Razor seem excessive?
- Generating code from DSLs
- Generating classes from config (or databases)

***

## CodeDOM
### [mostly demos]

- Been around since .NET 1.1
- Similar to DOM on the web
    - In-memory representation of code
    - On the web, we can manipulate DOM with JS
    - In .NET, we can generate DOM with .NET
- Works with a number of languages


***

## Reflection.Emit
### [mostly demos]

***

## Expression Manipulation

Mostly demos.













***

### Drive-By of other .NET Metaprogramming topics

- 'dynamic' and the DLR
- F# Type Providers
- F# Code Quotations
- Roslyn
- Domain-Specific Languages
- Aspect-Oriented Programming

***


## Resources

- Books
    - Metaprogramming in .NET
    - C# Smorgasborg
    - CLR via C#
    - C# 5.0 in a Nutshell
    - F# for C# Developers
- Pluralsight
    - Practical Reflection in .NET
    - Understanding Metaprogramming
    - Microsoft Intermediate Language
    - Understanding Metaprogramming
    - C# Language Internals (Parts 1 and 2)
    - T4 Templates

***

# Final Questions?
## Bug me.

- @stachudotnet [twitter, facebook, github]
- Ask for a business card
- Bug me during drinks at EOD
- StachuKorick@gmail.com
- 7178777628
