# HashLang

HashLang is a simple, toy programming language designed for educational purposes. It introduces basic concepts in compiler design, such as lexical analysis, parsing, and execution. The project implements a basic interpreter for HashLang, which allows users to define variables, print values, and interact with a command-line interface.

## Features

- **Basic Command Execution**: Execute commands such as printing and assigning values.
- **Variable Assignment**: Assign values to variables.
- **Print Statements**: Output strings and variable values.
- **Exit Command**: Gracefully terminate the interpreter session.

## Example Usage

```
>>> Print "hello"
hello was entered
>>> let x=4
x=4 was assigned
>>> print x
4
>>> exit
```

## Core Components

### 1. Lexical Analyzer (Tokenizer)
The lexical analyzer breaks the input into tokens, which are the smallest meaningful units in the language (e.g., keywords, identifiers, literals, operators).

### 2. Parser
The parser analyzes the sequence of tokens to ensure they conform to the language’s grammar. It uses a context-free grammar to construct a parse tree or abstract syntax tree (AST).

### 3. Interpreter
The interpreter executes the commands defined in the AST. It supports:
- Evaluating expressions
- Managing a symbol table for variable storage
- Executing commands in a sequential manner

## Grammar
The following context-free grammar defines the syntax of HashLang:

```
<program>       ::= <statement> | <statement> <program>
<statement>     ::= "Print" <expression> | "let" <identifier> "=" <value> | "exit"
<expression>    ::= <string> | <identifier>
<value>         ::= <number> | <string>
<identifier>    ::= [a-zA-Z_][a-zA-Z0-9_]*
<string>        ::= \"[^"]*\"
<number>        ::= [0-9]+
```


## Implementation Overview

1. **Lexical Analysis**: Tokenizes user input into keywords, identifiers, operators, and literals.
2. **Parsing**: Validates the syntax and generates an AST.
3. **Execution**: Interprets the AST and performs actions like printing or variable assignment.

## Extending the Language
HashLang is designed to be extensible. You can add new features like loops, conditionals, or functions by updating the grammar, parser, and interpreter components.

## References
- [Context-Free Grammar](https://en.wikipedia.org/wiki/Context-free_grammar)
- [Parsing](https://en.wikipedia.org/wiki/Parsing)
- [Compiler Design](https://en.wikipedia.org/wiki/Compiler#/media/File:Compiler.svg)
