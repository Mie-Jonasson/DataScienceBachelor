# Exam Notes - Second Year Project
On subjects concerning Natural Language Processing from basics to complex language modelling. The Lecturers surround the following subjects:
![](figures/lecture%20overview.PNG)

## PART I - Basics
### *What is "Natural Language Processing" about?*
Most data in this world is unstructured free text data. 
Being able to 'understand' and analyze texts the same way humans do in a computerized way is the ultimate goal of of the field. 
The field consists of a large variety of different tasks and methods that help interpret and process free text (Natural Language) or even information extraction for search algorithms like google.

Natural Language Processing is an **important** field, because it helps us communicate more effectively (helping us re-phrase, put commas and spell-check) even across languages and cultures (computer translation).

There are many diverse challenges in language, that do not fit how a machine works. Machines need to take very specific instructions to produce very specific results. Some challenges include:
- **sentiment classification** is an interesting subfield where the *meaning* of words (or sequences of words) make a difference to the human understanding of either a positively or negatively loaded sentence.
- When **generating language** the order and form of words is also an essential part of formulating a comprehensible and correct sentence for the circumstance.
- A huge challenge is also **ambiguous** words or even entire sentences. On their own they might have several very different meanings and use cases. Ambiguity might manifest itself on many different levels of language (*lexical*, *syntax*, *semantics*, *pragmatics*)

### *What is a Token?*
Here are a few important distinctions when we talk about *tokenizing* a text / string:
- A **character** is a single letter, symbol, space or similar
- A **string** is a sequence of characters
- A **token** is a collection of characters in a single meaningful group (could be a word with/without punctuation)

### *How do i use RegEx to extract meaningful tokens (Tokenization)?*
Regular Expressions can be used to define specific patterns of characters that we would like to extract. The following notations may be used in any combination:
- **[12abc]** - any single character between the brackets is matched
- **[A-Z]** - any single character within the range (here, uppercase letters)
- **[^abc]** - the '^' negates the brackets - and thus matches any single character not otherwise within the brackets.
- **a|b** - matches one of EITHER of string a or b
- **ab?** - matches 'a' followed by *0 or 1* 'b'
- **ab*** - matches 'a' followed by *0 or more* 'b'
- **ab+** - matches 'a' followed by *1 or more* 'b'
- **.** - matches any character

Further nice-to-knows:
- **^(regex)** - matches the regex if it is at the *start* of the line.
- **(regex)$** - matches the regex if it is at the *end* of the line.
- **\s** - matches whitespaces

But **How do we determine how to tokenize?**
There are several methods; we might either define a regular expression to describe what a gap between tokens look like.... or, we might define what the tokens themselves should look like!
- **Defining gaps**: problematic, as we likley dont handle punctuation too well!
- **Defining tokens**: problematic, as we might have words that dissappear because our regex pattern does not match them!
- **lexicon-based**: 're.compile(\<string>).findall(\<language>)'... but this is also complex af

### *How do i proces text in the LINUX command line?*
Using the commandline in general is important, as this is also how we would work with ITU HPC (High Performance Computer)!

**Syntax:** \<command> -\<option> \<value> \<input>

#### **Basic commands:**
- **cat** : print contents of file to StdOut
- **head** / **tail** : print beginning or end of files
    - **-n \<number>** : specify number of lines to fetch
- **wc** : wordcount of file (outout: #lines, #words, #characters, filename)
    - **-c** : characters only
    - **-w** : words only
    - **-l** : lines only
- **less** : Interactive reading of file
    - **scrolling** : space/enter/arrowkeys
    - **/** : searching
    - **q** : quit interactive application
- **pipe** : **a|b** : use to pass output from action 'a' to action 'b'
- **redirect** : **> filename.txt** : use to write output to file 

#### **Text Processing:**
- **grep "regexp" filename.txt** : matches a regular expression and returns all matches by default
    - **-i** : ignore capitalization
    - **-o** : match only regexp
    - **-n** : show line numbers
    - **-c** : count lines that match
    - **-v** : invert
- **sort filename.txt** : sorts the content of a file
    - **-n** : numeric
    - **-r** : reverse order
- **uniq** : removes adjacent duplicate lines
    - **-c** : return count
- **cut** / **paste** : for splitting / pasting columns in a file
    - **-d** : delimiter (default is tab)
    - **-f** : select fields
- **tr "FIND_STRING" "REPLACE_STRING"** : replace characters in string from StdIn
- **sed** : filtering and transforming text (used for replacing)
    - **-i** : inplace
    - **sed "s;FIND_STRING;REPLACE_STRING;g"**

### *What should i consider in a basic experimental setup?*
#### The first thing we consider is **splitting** into train-(dev/val)-test sets. This is important to:
- ensure integrity of our results, and 
- determine some kind of confidence in our predictions. 
- BUT! Beware... data *in the wild* often have a lot of unexpected behaviors. (i.e. the challenge of **domain adaption**)

Note, that using a **stratified split** is common practice. I.e. we split the data based on a criteria, like; *time, document, main speaker, write/speaker*, and ensures that our estimated performance resembles a real life situation the best!

A commonly used method is **k-fold** validation, for which the data is split into *k* sections. Then the model is fit and validated k times, with each fold being the validation data once.

#### The next thing we need to consider is **baselines**, for which we have several options;
- The simplest possible approach (predicting to the most common sample)
- A simple classifier (f.ex. logistic regression)
- The state-of-the-art (for which we want to make improvements by use of some method)

Which baseline to use depends on the research question, but the better the baseline, the more relevant an answer we will produce from our results.

#### The third thing to consider is **which metric** we should base our analysis / model selection / reporting on. Some basic rules for choosing a metric:
- If the metric used in previous work makes sense, use that too!
- Use a metric the reflects the *goal* of the system.

Some common metrics that we should consider:
- *Accuracy*: fraction of correct predictions
    - Good for balanced label distributions
- *Recall*: for a class, number of instances (Ground Truth) correctly classified
- *Precision*: for a class, number of predictions correctly classified
- *F1-score*: harmonic mean between recall and precision
    - Per class: remember there are different averages to consider! (weighted, macro, micro, etc.)
- *Span-F1*: F1-score for span-based tasks (NER)

![](figures/rob_metric.PNG)

#### We might also be interested in **statistical significance** of our results. For that we can consider the following methods:
- *paired bootstrap* (i.e. t-test for equal means)
    - Bootstrap n random samples of prediction
    - calculate significance of model A performing better than model B
- *ASO test* (Almost Stochastic Order)
    - For comparing multiple versions of the same model
    - [Github Repo W. Implementation](https://github.com/Kaleidophon/deep-significance)

**REMEMBER** - Often Quantitative and Qualitative approaches compliment each other a lot!