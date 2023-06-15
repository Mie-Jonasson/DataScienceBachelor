# Exam Notes - Second Year Project
On subjects concerning Natural Language Processing from basics to complex language modelling. The Lecturers surround the following subjects:
![](figures/lecture%20overview.PNG)

---
---
## PART I - Basics
Lectures: 1-2

---
### *What is "Natural Language Processing" about?*
Most data in this world is unstructured free text data. 
Being able to 'understand' and analyze texts the same way humans do in a computerized way is the ultimate goal of of the field. 
The field consists of a large variety of different tasks and methods that help interpret and process free text (Natural Language) or even information extraction for search algorithms like google.

Natural Language Processing is an **important** field, because it helps us communicate more effectively (helping us re-phrase, put commas and spell-check) even across languages and cultures (computer translation).

There are many diverse challenges in language, that do not fit how a machine works. Machines need to take very specific instructions to produce very specific results. Some challenges include:
- **sentiment classification** is an interesting subfield where the *meaning* of words (or sequences of words) make a difference to the human understanding of either a positively or negatively loaded sentence.
- When **generating language** the order and form of words is also an essential part of formulating a comprehensible and correct sentence for the circumstance.
- A huge challenge is also **ambiguous** words or even entire sentences. On their own they might have several very different meanings and use cases. Ambiguity might manifest itself on many different levels of language (*lexical*, *syntax*, *semantics*, *pragmatics*)

---
### *What is a Token?*
Here are a few important distinctions when we talk about *tokenizing* a text / string:
- A **character** is a single letter, symbol, space or similar
- A **string** is a sequence of characters
- A **token** is a collection of characters in a single meaningful group (could be a word with/without punctuation)

---
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

---
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

---
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


















---
---
## PART II - Data Collection and Basic Modelling
- Lectures: 3-5
- [Interesting report on Datascience](https://visit.figure-eight.com/rs/416-ZBE-142/images/CrowdFlower_DataScienceReport.pdf)

---
### *How do I get data?*
There are 2 main approaches for selecting data for a project:
- **Top-down**: We specify our *task* first and try to find data to work with later.
- **Bottom-up**: We find the *data* first, and determine our tasks based on what is available.

A popular source for natural language data is **scraping** or using **open APIs**... But the problems with this type of data gathering is that we cannot freely re-distribute the data, offering *challenges in terms of reproducibillity* as we cannot share data.

Whenever we have a new dataset it is important to create a **dataset statement** that specifies a variety of things (find [guides](https://techpolicylab.uw.edu/wp-content/uploads/2021/10/Data_Statements_Guide_V2.pdf) online). We should always be clear about the origin and possible biases of our dataset, as we can never guarantee a dataset to be completely representative of a population. See below picture from the slides for main parts that should be present in a dataset statement:
![](figures/dataset_statement.PNG)

**biases** can appear from many different things; examples from data collection processes are speaker demographics (who answers a survey) or sampling method (we only gather data from internet / by phone limiting the reachable demographic).

---
### *Once I have some cool data, how do I obtain annotations?*
Once we have data and determine to annotate it for some type of task, we will need to obtain these annotations from somewhere credible.

When we have **Human Annotations** we are bounded by how well *humans* can do the task we want to obtain *gold standards* for. Note that some tasks are harder than others, and the demographic of annotators might sometimes only be linguists to ensure proper gold standards.
Human annotations are also **expensive**, so we often use a small part of the data to *iteratively* let annotators learn the guidelines by heart and discuss ambiguous cases / refine guidelines. Once the **kappa score** converges, we divide the rest of the dataset by the number of annotators and let it be annotated by a single individual.

We consider all annotations and guidelines to be a trade-off between:
- *Informativity*: The most useful annotations for your task / goal.
- *Correctness*: Easier cases will ensure higher correctness than complex cases.

There exists **freely available** annotated datasets for a lot of tasks - sentiment analysis, author identification, language modelling etc. These can be used, but be aware of their dataset statements and annotation guidelines, as you should *always validate* the integrity of things produced by others, to ensure that you trust the results.

---
### *What are the practicalities of setting up an annotation proces?*
Human Annotations are obtained through an **iterative proces**, consisting of the four steps:
- *Model and Guidelines*: here we define the way we annotate. Include good examples and examples of hard cases for annotators to review.
- *Annotate*: A selection of data items are annotated by groups of annotators (at least two)
- *Evaluate*: The annotation are evaluated (think, intra- and inter-annotator aggreement :D)
- *Revise*: Revise the types of errors and difficult / ambiguous cases - then go back to reviewing and updating step 1!

When defining the **Annotation Guideline** we should think of them as instructions that should not be possible to misinterpret. The main questions we should ensure to answer are:
- What is the purpose?
- What is each label called and how is it used? (include examples for clarity)
- What parts of the text do you want annotated?
- How are difficult cases handled? (including indicators for ambiguity / uncertainty)

For **Evaluating** annotations we usually work with *inter-annotator agreement* (i.e. agreement between annotators). But how do we measure agreement? well, that really depends on the task, but here are some cool options to consider:
- *Cohen's Kappa*: (observed_agreement - agreement_by_chance) / (1 - agreement_by_chance)
    - Takes chance into account
    - scale is 0-1 (0 equals random guessing)
    - Good for 2 annotators
- *Fleiss Kappa*:
    - Takes chance into account
    - scale is 0-1 (0 equals random guessing)
    - Good for >2 annotators

How do i calculate agreement_by_chance? (Remember, the more classes, the lower the expected agreement will become!)
Here is a small example from class, including cohen's kappa calcualtion:
![](figures/expected_agreement_example.PNG)

**rule-of-thumb** for interpreting Kappa:
- 0 = Random
- <0.4 = Weak
- 0.4-0.6 = moderate
- 0.6-0.8 = strong
- 0.8-0.99 = almost perfect
- 1 = perfect

---
### *What is Sequence Labeling?*
Sequence labellng describes any type of task that labels each element in a sequence. Real-world applications include Part-Of-Speech tagging, Named Entity Recognition and many more!

In particular, a sequence labeling task takes an input vector in length *s* of elements, and produces an output vector of labels in the same length. It is a particular type of *structured prediction problem* where we predict each label based on some classifier model.

When using it for Named entity recognition, we know that some entities might span several tokens. We might benefit from using BIO or more complicated labelling techniques:
![](figures/bio_ner.PNG)

---
### *Tell me a little more about Part-of-Speech Tagging*
Part-Of-Speech Tagging is a sequence labelling topic for which we assign each token in a sentence with the related grammatical tag (i.e. punctuation, verb, determiner, nound, pronoun etc,)
A good rule for determining a class of a word, is that replacing it by another word of the same class should not impact syntactical correctness!

There exists many different tag-sets, but for simpler tasks we might want to stick to the *Universal POS tags* (12-17 tags). The Penn Treebank tag-set is a more granular tag-set consisting of 45-52 tags (verbs are f.ex. divided into tenses)

We can define two main groups of tags when we consider part-of-speech:
- **closed class** : classes that have a relatively fixed set of words
    - prepositions (on, under, over, near, by, at, from, to, with)
    - particles (up, down, on, off, in, out, at, by)
    - determiners (a, an, the, many, some, all, no, which, what, this, that)
    - coordinating conjunctions (and, or, as, if, when) - syntactically equal parts
    - pronouns (she, who I, others)
    - auxiliary verbs (can, may, should, are, was, is, will) - function word to express grammatical distinction
    - numerals (one, two, three, first, second, third)
    - adposition (in, for, at, from, by, as) - relations connected to nouns
- **open class** : 
    - adjectives (honest, pretty, cool, ugly, silent) - modifies nouns
    - adverbs (never, quite, actually) - modifies verbs, adjectives or adverbs
    - interjections (please, thanks, yes, well, lol, hey, ok)
    - nouns (wine, glasses, history, science)
    - proper nouns (Emma, Bilka, ) - named objects / entities
    - verbs (lived, stinking, creating)
    - pronoun (his, nothing, my, he, we)
    - subordinate conjunctions (but,, for, if) - syntactically subordinating parts
- **other** : anything un-classified
    - punctuation (!, ., ?)
    - symbols (#, @, $, %, :D)
    - X (miscellaneous!)

### *How do i use words as features?*
The simplest way of encoding words as features is to use something similar to the concept of One-Hot Encoding. I.e. we create a vector of 0's in the length of the vicabulary (i.e. unique words), and for each sentence we put a 1 for those tokens that are present in the set of tokens. 

This method is called **Bag-of-Words**, as we disregard the context of the tokens and any ambiguity of word meanings. If we encounter spelling mistakes or unknown words, we quickly fail to have proper support... but natural language is incredibly *sparse* - i.e. few very frequent words, many rare words (**Zipf's law**)

























---
---
## PART III - Basic Embedding based Methods (+Bias)
Lectures: 6-7 + 13






















---
---
## PART IV - Relation Extraction
Lectures: 8

























---
---
## PART V - Neural Language Models
Lectures: 9-10




















---
---
## PART VI - Contextualized Language Models
Lectures: 11-12




























---
---
---
# HIGHLIGHTS