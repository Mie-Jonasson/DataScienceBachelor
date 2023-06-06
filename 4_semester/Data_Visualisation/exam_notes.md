# Data Visualisation - Exam Notes
---
## **Part I - Foundations**
- Lectures: 1-3
- Chapters: 1-2
- Cheatsheet: Visual_Vocabulary.pdf

---
### *What is a visualization?*
The book defines;
- **Visualization**: An umbrella term for any kind of visual
- **Chart**: An encoding of data with symbols (synonyms: "plot", "graph", "diagram")
- **Infographic**: A multi-section visual communicating one or more specific messages; Shows a small amount of data, and has focus on the story.
- **Data Visualization**: A display of data to *enable analysis, exploration and discovery*; conceived as tools to gain insights / make your own conclusions.
- **News Application**: A visualization allowing people to relate the data to their own personal life. Can, for example, be a tool helping you decide between health care options near you.

---
### *Why do we visualize?*
- **vision** is the most powerful of all of our senses.
- Just looking at numbers, it can be hard to find patterns and come to conclusions - using visual cues to display the data helps the brain in analysing and exploring data. **Patterns become apparent**.
- We are drowning in data - we need to make sense of it in a way that summary statistics cannot grasp!

---
### *What are the 5 qualities of a good visualization?*
The 5 qualities as defined by *Enrico Bertini*:
- **Truthful**: A visualization that is honest and truthful, is not trying to mislead you (intentionally or unintentionally). Do not hide data, excessively summarize data and be aware of your own perception and bias. Apply *critical thinking* whenever you sort, filter and display data!
- **Functional**: A visualization that is functional, will help the audience interpret the data correctly. We want to show our points in a way that the brain can easily understand, *purpose* is the focus.
- **Beautiful**: A visualization that is beautiful, will be interesting to the audience and make them more motivated to spend time interpretting it. Beauty is *subjective* and out goal is therefore designing to be *experienced as beautiful by as many people as possible*.
- **Insightful**: A visualization that is insightful, will clear the path to making valuable discoveries. Visualizations are not just pictures, they need to award us new knowledge. Consider:
- - *Spontaneous Insights*: You see it right away; "a-ha" moment.
- - *knowledge-building insights*: gradual process of exploration to build knowledge.
- **Enlightening**: A visual that is enlightening, is a graphic that has all the other 4 qualities and excel at *changing people's minds for the better*. Enlightening the user / reader of the visualization means making a difference in the way they perceive the world or a particular topic.

---
### *Can you give me a meaningful visual vocabulary?*
Depending on your use-case you might want to deploy a different model (or several models) to best help your audience achieve insights... but how do you find out which type of visual to use? 

One good tool is to use visual vocabulary overviews as the one located in this folder; *Visual_vocabulary.pdf !* Further suggested ressources can be found in the slides of lecture 3, but here are a few:
- [Data Viz Project](https://datavizproject.com/)
- [Data Viz Cataloque](https://datavizcatalogue.com/)
- [Visualising Data](http://chartmaker.visualisingdata.com/) - solutions for particular visuals in particular programs (i.e. Tableau, R, Pandas, Flourish)
- [Xenographics](https://xeno.graphics/) - has a lot of interesting and weird plots!














---
---

## **Part II - Visual Perception**
- Lectures: 4
- Chapters: 5 + additional reading
---
### *What is the visual hierarchy?*
The *Hierarchy of elementary perceptual tasks* was put together by two statisticians to rank how easy it is for humans to accurately estimate numbers based on different visual properties. 

This hierarchy is built solely on *ease of interpretation* for the human brain. The Hierarchy goes from accurate estimates -> general estimates:
- Position along common scales
- Position along identical non-aligned scales
- Length
- Direction / slope
- Angle - Area
- Volume
- Shading
- Color Hue

The higher in the hierarchy your main encodings come from, the easier it is for the intended audience to come to conclusions and make good estimates. **BUT** it always depends on the use-case - for specific purposes a lower rated encoding might provide a better contextual meaning to the reader than ones higher up in the hierarchy.

*Hierarchies are slightly different depending on type of variable* they say...

![plot](pictures\visual_hierarchy.PNG)

---
### *What is it with human visual perception?*
**Attention** has it's limits - we have all tried those weird games where your overlook changes because you are focused on something else... If not, i can recommend watching Brain Games (can be found on Disney+)!

Our brains are good at detecting things that **stand out**, but find it hard to f.ex. count the number of items in a crowd. Some attributes make items stand out more than others!

---
### *How can i create visuals that are effective in the different channels?*
There are 5 types of channel effectiveness that we will consider:
- **Accuracy**: how accurately can I estimate values?
- **popout**: how easily can I spot one value over the rest?
- **discriminability**: how many different values can I perceive?
- **seperabillity**: how well can I seperate different encodings?
- **grouping**: how well can I perceive groups?

For **Accuracy** we should follow the *visual hierarchy*! But, it does depend on the type of variable (Nominal, Ordinal, qualitative) - see more details under the *visual hierarchy* section :D

For **popout** we should leverage *pre-attentive processing*, which is what we perceive automatically and without much thought. View the *pre-attentive processing* section for further details.

For **discriminability** we should be aware of the number of different values within an encoded attribute. One might consider *binning* to lessen the amount of different types within an encoding type that might be hard to distinguish.

For **seperability** we should ensure choosing attribute encodings that interfere as little as possible: height-width or color-color a problematic, while placement-color is easy to perceive both encodign at the same time!

For **grouping** we should apply *gestalt principles* which rank channels in terms of how well they communicate groups. View the *gestalt principles* section for further details.

---
### *What is pre-attentive processing?*
Pre-attentive processing is what happens before we start that actual processing of data. It is the perception that happens automatically.
An overview of pre-attentive attributes can be seen in the below image.
![](pictures/pre_attentive.PNG)

---
### *What are the Gestalt Principles?*
The gestalt principles is a ranking of how different properties helps us in decoding grouping information in data. Here they are in order:
- **proximity**: Objects close to each other are often perceived as having *similar characteristics*.
- **similarity**: Objects with distinct similarities (color, shape) appear to have similar characteristics; useful for grouping categories.
- **segregation**: Objects that are within a box / circle appear to be sharing some *similar characteristics*.
- **connectivity**: Objects that are connected (f.ex. dots connected by a line) appear to be of a *similar/same* group.
- **continuity**: Objects are expected to continue following the smoothest path possible. (especially with lines...)
- **closure**: Objects with missing data points are expected to follow a smooth path between the two endpoints. (smooth interpolation -> similar point to continuity!)

















---
---

## **Part III - Information Design**
- Lectures: 5
- Chapters: 5 
- Cheat Sheet: Building_Charts_Cheatsheet.pdf
---
### *What are some basic rules for choosing a chart vs. table?*
**Tables** are awesome when we want to be precise, compare specific values or want to look up a specific value.

**Charts** are awesome when we want an overview and try to reveal patterns / relationships.

---
### *Tell me about Data Ink vs. non-Data Ink!*
Data Ink is used to describe things in a chart directly displaying / related to the data we are trying to show. Non-Data Ink on the other hand is all the extra things - legend, axes, numbers, labels, grid lines etc.

We want to **minimize non-Data Ink** to the point where our point just comes across and the chart is readable for the audience. We basically want to remove clutter and redundant information, to allow the audience to focus on what is important; the data!

---
### *Give me the main design points to consider!*
- **Minimize non-data ink**: Remove clutter and allow focus solely on the data.
- **Place axis where relevant**: If your interesting insights are at the top, place your axis there!
- **Consider aspect ratios**: When your plot is taller, lines will look too ragged. When your plot is wider, lines will look too smooth. 
- **Consider orientation**: Sometimes a horizontal bar plot will give your data more space and allow more easily reading the data.
- **Use soft color palettes**: to allow ease of reading the chart, allow possibility to enhance particular points with saturated colors. **ALSO** remember to be color-blind sensitive!
- **Be consistent with colors**: Use the same color for that same item across charts. This will make it easier for the audience to spot trends.

---























# Highlights
## *Overview First, Zoom and Filter, Details on Demand!*
---
---
## **What are the 5 qualities of a good visualization?**
The 5 qualities as defined by *Enrico Bertini*:
- **Truthful**: A visualization that is honest and truthful, is not trying to mislead you (intentionally or unintentionally). Do not hide data, excessively summarize data and be aware of your own perception and bias. Apply *critical thinking* whenever you sort, filter and display data!
- **Functional**: A visualization that is functional, will help the audience interpret the data correctly. We want to show our points in a way that the brain can easily understand, *purpose* is the focus.
- **Beautiful**: A visualization that is beautiful, will be interesting to the audience and make them more motivated to spend time interpretting it. Beauty is *subjective* and out goal is therefore designing to be *experienced as beautiful by as many people as possible*.
- **Insightful**: A visualization that is insightful, will clear the path to making valuable discoveries. Visualizations are not just pictures, they need to award us new knowledge. Consider:
- - *Spontaneous Insights*: You see it right away; "a-ha" moment.
- - *knowledge-building insights*: gradual process of exploration to build knowledge.
- **Enlightening**: A visual that is enlightening, is a graphic that has all the other 4 qualities and excel at *changing people's minds for the better*. Enlightening the user / reader of the visualization means making a difference in the way they perceive the world or a particular topic.

---
## **What is the visual hierarchy?**
The *Hierarchy of elementary perceptual tasks* was put together by two statisticians to rank how easy it is for humans to accurately estimate numbers based on different visual properties / encodings. 

This hierarchy is built solely on *ease of interpretation* for the human brain. The Hierarchy goes from accurate estimates -> general estimates:
- Position along common scales
- Position along identical non-aligned scales
- Length
- Direction / slope
- Angle
- Area
- Volume
- Shading
- Color Hue

---
## **How can i create visuals that are effective in the different channels?**
There are 5 types of channel effectiveness that we will consider:
- **Accuracy**: how accurately can I estimate values?
- **popout**: how easily can I spot one value over the rest?
- **discriminability**: how many different values can I perceive?
- **seperabillity**: how well can I seperate different encodings?
- **grouping**: how well can I perceive groups?

For **Accuracy** we should follow the *visual hierarchy*! But, it does depend on the type of variable (Nominal, Ordinal, qualitative) - see more details under the *visual hierarchy* section :D

For **popout** we should leverage *pre-attentive processing*, which is what we perceive automatically and without much thought. View the *pre-attentive processing* section for further details.

For **discriminability** we should be aware of the number of different values within an encoded attribute. One might consider *binning* to lessen the amount of different types within an encoding type that might be hard to distinguish.

For **seperability** we should ensure choosing attribute encodings that interfere as little as possible: height-width or color-color a problematic, while placement-color is easy to perceive both encodign at the same time!

For **grouping** we should apply *gestalt principles* which rank channels in terms of how well they communicate groups. View the *gestalt principles* section for further details.

---

## **What are the Gestalt Principles?**
The gestalt principles is a ranking of how different properties helps us in decoding grouping information in data. Here they are in order:
- **proximity**: Objects close to each other are often perceived as having *similar characteristics*.
- **similarity**: Objects with distinct similarities (color, shape) appear to have similar characteristics; useful for grouping categories.
- **segregation**: Objects that are within a box / circle appear to be sharing some *similar characteristics*.
- **connectivity**: Objects that are connected (f.ex. dots connected by a line) appear to be of a *similar/same* group.
- **continuity**: Objects are expected to continue following the smoothest path possible. (especially with lines...)
- **closure**: Objects with missing data points are expected to follow a smooth path between the two. (smooth interpolation -> similar point to continuity!)

---

## **Give me the main design points to consider!**
- **Minimize non-data ink**: Remove clutter and allow focus solely on the data.
- **Place axis where relevant**: If your interesting insights are at the top, place your axis there!
- **Consider aspect ratios**: When your plot is taller, lines will look too ragged. When your plot is wider, lines will look too smooth. 
- **Consider orientation**: Sometimes a horizontal bar plot will give your data more space and allow more easily reading the data.
- **Use soft color palettes**: to allow ease of reading the chart, allow possibility to enhance particular points with saturated colors. **ALSO** remember to be color-blind sensitive!
- **Be consistent with colors**: Use the same color for that same item across charts. This will make it easier for the audience to spot trends.

---