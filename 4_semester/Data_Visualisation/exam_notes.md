# Data Visualisation - Exam Notes
---
## **Part I - Foundations**
- Lectures: 1-3 (+11)
- Chapters: 1-2
- Cheat Sheet: Visual_Vocabulary.pdf

---
### *What is a visualization?*
The book defines;
- **Visualization**: An umbrella term for any kind of visual
- **Chart**: An encoding of data with symbols (synonyms: "plot", "graph", "diagram")
- **Infographic**: A multi-section visual communicating one or more specific messages; Shows a small amount of data, and has focus on the story.
- **Data Visualization**: A display of data to *enable analysis, exploration and discovery*; conceived as tools to gain insights / make your own conclusions.
- **News Application**: A visualization allowing people to relate the data to their own personal life. Can, for example, be a tool helping you decide between health care options near you.

---
### *What are Xenographics?*
Xenographics are graphics that are unknown... *one-of-a-kind* graphics that are useful only in very particular cases, but it comes with a *trade-off* in terms of the viewers first having to understand how to read your plot!

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
    - *Spontaneous Insights*: You see it right away; "a-ha" moment.
    - *knowledge-building insights*: gradual process of exploration to build knowledge.
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
- Cheat Sheet: -
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

![plot](pictures/visual_hierarchy.PNG)

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

## **Part III - Visualization Choices**
- Lectures: 5-6 + 9 + 13
- Chapters: 5 + 10
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
- **Remember the rules of thumb**: at max; 5 lines, 10 bars, 7 slices and 8 colors!

---

### *Usual pain points of visualising*
- **Uncertainty** - refer to part VI
- **seasonality** - how do we make seasonal patterns clear to the viewer?
    - Method 1: *annotations* are used to point out particular points / areas.
    - Method 2: *small multiples* are used to display the same seasonality across different aligned charts.
    - Method 3: *overlapping timeframes* are used to display history as well as latest observations.
    - Method 4: *accumulation* creating accumulative charts that can be overlayed in a single chart.
    - Method 5: *aggregation* over the season; reduces noise but might be an overismplification of the patterns.
    - Method 6: *peakspotting timeline* displays only the peak of each series of attributes. Allows a high-level overview of trends.
    - Method 7: *animation*
- **outliers** - how do we handle outliers in visualization? Outliers are often interesting, and even though our intuition says to remove them (simplifying assumption), they might actually be the most interesting insight!
    - Method 1: Make a seperate axis / truncation for the outlier... and make sure it is clear to the viewer!
    - Method 2: remove the outlier and *make a viewer note* about it!
    - Method 3: do nothing... if the outlier is the point, then losing granularity for non-outliers is fine.
- **log-scales** - how do we use them? does the public really understand? Log-scales are amazing for showing proportional gain of differently sized series!
- **bar transformations**

---
### *What can you tell me about visualising networks?*
First things first, there's three main things we consider when visualising networks; node attributes, edge attributes and layout. Here we will shortly go through some best practices.

When it comes to **node attributes** we have a few tools:
- *node size*: the bigger a node is, the more important it is! (consider degree, centrality measures or a given attribute - *quantitative*)
    - Fall-pit 1: We model using the radius, but the brain conceives importance in terms of area! We should ensure that distinctions are based on area of node :D
    - Fall-pit 2: We cannot actually see the difference in sizes... We should enhance the differences!
    - Fall-pit 3: Some nodes becomes way too big, others become invisible... We should make the scale exponential instead of linear, to ensure a nicer overview.
- *node color*: To display *qualitative* information. (community, category etc.)
    - CAN be used for quantitative attributes with diverging / sequential color schemes, but thes should be avoided!
- *node labels*: not really relevant unless you actually need them for interpretation and cannot put them in tool-tip... Basically a glorified wordcloud when you add labels :D

When it comes to **edge attributes** we have many of the same tool (and fall-pits) as with nodes:
- *edge thickness*: corresponds 1:1 with node size :D
- *edge color*: VERY different from node color... Edges rarely have any type of qualitative information worth visualizing, **BUT** for big hairballs we can use *edge transparency* to make it less hair-ball-y.
- *edge labels*: please just dont... really only if it's a life-or-death!

When it comes to **network layouts** we have several different algorithms to help us get a better layout that allows a better overview of the network.
- *Force-Directed layouts*: Works well for sparse, clustered and sphered networks! Allows clusters / groups to be densely connected while adding distance betweens node groups with fewer inter-links. Ordered from least compact to most compact:
    - Spring Embedded
    - Force Directed
    - Organic
    - Compound Spring Embedded
- *t-SNE layout*: is a wild dimensionality reduction, that produces a single set of coordinates that can be used to plot the network.
- *hierarchical layout*: really only works for trees or DAGs... 
- *circular layout*: an interesting layout, but remember to consider: 
    - How you arange nodes is important
    - Consider using edge-bends to display "highways" between clusters.

---
### *What can you tell me about visualising geospatial data?*
The most important thing to remember when working with **maps** is that:
- *All maps lie*: All maps are simplifications and subject to what choices have been made when drawing it. The world map we know and love highly exagerates land mass closer to the north pole and squishes landmass closer to the equator.
- *All maps are a tradeoff of shape, area or both*: A map cannot tell the truth in both of these cases, and a tradeoff has to be made to suit the needs of the particular map. The map we know best (Mercator Projection) sacrifices area but has the shape right.

Maps can be tricky, and we will mainly use a map when the geospatial part is important for the viewer to understand the data, or might offer insights that would otherwise be hidden (i.e. *invisible patterns* when not in spatial context). Some important considerations when visualising on maps:
- **Data Ink** should be minimized. We dont want to have too much color or detail in the background. Maps are a special case, because a blue-green encoding of ocean-land and possibly roads might be needed to help the viewer in establishing *context*!
- **What Data** you visualize is important  for the choice of map and to ensure that your message comes across!
- **Unit size** might make a difference; consider using the smallest units possible to allow for the most nuanced view of the data.
- **Color Schemes** should have a lightness-to-darkness, instead of just being two colors. Doing this ensures both printer friendliness (gray-scale) and easier interpretation (remmeber - saturation is easier for the brain than hues!).

We consider several different types of maps:
- **Reference Maps**: Purpose is to show locations of things.
- **Thematic Maps**: Purpose is to display data in a geo-spatial context.
- **Technical Maps**: Purpose is to enable navigation / show ownership boundaries.
- **Socio-Economic Maps**: Purpose is to display information about politics, population, economy, epidemics etc.
- **Physio-Geographical Maps**: Purpose is to display information about physical things: soil, vegetation, geological etc.

How do we visualize numbers on a map? there are many different ways of encoding, from most used to least used:
- *Proportional Symbol*: This type of map will show the value by f.ex. a circle whose size corresponds to the data value.
- *Choropleth*: This type of map will have each section of land colored in a gradient. Land sections can be defined both as entire countries or cities / suburbs etc.
- *Isopleth*: This type of map is also called a 'heat'-map, and is used to visualize continuous variables.
- *Cartograms*: Here, the landmasses themselves are scaled similar to the target variable.
- *Flow*: This type of map shows the flow between geographic locations, similar to encoding a network where layout is determined by geographical location.

At last, we will shortly discuss **binning**. Binning is useful when we want to make it easier for the viewer to distinguish between colors; i.e. we make a discrete color set instead of a continuous. There are several methods for dividing data points into bins:
- *equal interval*: we simply divide the span between minimum and maximum into n same-sized bins.
- *quantile interval*: we divide the datapoints into n bins that each contain the same number of data points.
- *natural breaks*: we divide the datapoints into m bins that condense a naturally occuring grouping.
- *Manual*: you decide hun, anything you want!


















---
---

## **Part IV - I Am Now a Designer**
- Lectures: 7-8
- Chapters: -
- Cheat Sheet: Beautiful_Charts_Cheatsheet.pdf
---
### *What are the design ideas we should consider in information design?*
One thing we might consider is the **task** that the audience will need to do to understand and use our visualization. The usual workflow and *information seeking mantra* that we might use as a guideline is:

*Overview First, Zoom and Filter, then Details-on-Demand*

Another thing is the usefulness / **goal** of visualising. We might consider it a tool for a very specific purpose, or to retain several uses depending on the application.

The main **problem-solving tasks** we try to solve with visualisation are:
- *Exploratory tasks*: helps the user make their own exploration of the data.
- *confirmatory tasks*: helps the user test a hypothesis.
- *production-based tasks*: helps user visualise their proven hypothesis.

We also consider **actions** and **targets**. When you have a desired task, you often phrase it as an action you want to use towards a target. *Actions* can be analytical (discover, derive, present), comparison (compare, identify) or search (lookup, explore) and *targets* can both be broad (trends, features, outliers) or specific (correlation, extremes).

---

### *Can you tell me about the design proces?*
Designing anything is an **iterative proces**. We start by making a draft with just the bare essentials, test it out (possibly on representatives of the audience) and make some changes to accommodate whatever was unclear or weird.

Secondly, we should attempt to apply design principles through **design thinking**:
- *user first*: design for the user of whatever your are designing, as they are the ones that are going to benefit and be annoyed by the end-product.
- *it's not the user's fault*: we should design all things to be intuitive to use... if we fail, it will cause a lot of frustrations for our end users.
- *always observe*: everything around us is designed by someone. Be aware of your surroundings, and observe how people and things interact.

---
### *What are Normans 4 design principles?*
Design principles are unique to each organisation and to each visualisation designer. Thus this is just one suggestion making some good points:
- **Affordances**: A good design ensures that the intended actions are easy to see, while unintended actions are hidden. Affordances are *all possible actions*!
- **Constraints**: Ensure fewer errors by the user by constraining unintended actions to become impossible!
- **Conceptual Models**: Our minds get frustrated when we have to learn how to use a seemingly arbitrary tool / object.
- **Feedback**: Any design needs to give some sort of feedback to allow the user to know something changed following their action - pushed a button, changed a slicer etc.

**Rule of Thumb**: If you need a sign to tell the user how to use it, the design is ineffective!

---
### *What is the Von Restorff effect?*
The Von Restorff effect describes, that the item that *stands out* is the most likely to be remembered by the user. This might f.ex. be a button that is bright blue while everything else is gray, or a highly saturated bar in a bar chart where everything else has soft colors. I.e. it *draws attention* and creates a *meaningful memory* for the user.

---
### *Now, what can you tell me about aestethics in data viz?*
Beauty is all subjective. Not all people will find the same things beautiful, but yat there are 3 main types of beauty: 

- *dynamic* beauty leverages unexpectedness and flow, 
- *harmonious* beauty leverages flawless interaction between nice parts and 
- *inherent* beauty leverages the contrast towards an opposite.

But why do we even care about aestethics and things being beautiful? well...
- It makes the user comfortable in **spending more time** exploring the data.
- It helps in relation to **persuading** someone of your points (usability/effectiveness).
- It makes the visualization **memorable**.
- It awards more **clarity**.

Often, all we need is to **declutter** and make data as easy and intuitive to view and manage as possible!

---
### *But what is all that 'Graphical Excellence' about then?*
Graphical excellence is all about giving the viewer/user the most use of a visualization with as little ink and space as possible (Tufte's definition at least).

It's basically a lot about Data Ink ratio, meaning we want as high a fraction, of things shown in a visualization, to be directly related to the data as possible.

It's also a lot about small multiples and spark lines in relation to *as little space as possible*. Since small multiples and sparklines are effective in showing each their own story / trends but do not take up too much space...


























---
---

## **Part V - At last I Become a Storyteller**
- Lectures: 10 + 13
- Chapters: -
- Cheat Sheet: -
---
### *What are strengths of Author-driven vs. User-driven approaches?*
When we have a narrative that is **Author-driven**, we try to communicate a very particular message to the user. 
In this setting we create a story that we try to convey to the user, which inherently has limitations on the interactivity aspect. Properties are:
- Linear Ordering of Scenes
- Heavy Messaging
- No interactivity

When we have a narrative that is **user-driven**, we let the user pick their own path and embark into finding their own story and insights.
- No particular ordering
- No message
- Free Interactivity

---

### *Why do we really care about story-telling?*
When we tell stories it is all about prioritizing **a good story over a true story**... that's why we still love stories that are completely unrealistic, because they cause *emotions*. 
I.e. storytelling prefers: *speculation*, *exaggeration* and *excitement*. 

Another important factor is that **stories are persuasive**. When trying to persuade someone, there are the two main paths; story and rhetorical facts.

---

### *How do we create a persuasive story?*
The reason we *remember* stories, and also why they are so *persuasive* is due to **uniting emotions and ideas** to spawn attention ans energy.

For a story to be persuasive, it usually follows a structure:
- Start with balance
- create tention
- end with resolution

---

### *What can we learn from other fields of story-telling?*
Stories are used in many different settings and situations, but what can we learn from these different strategies?

**Journalism** has a classic setup to allow for the user to navigate the story... But remember, people usually only read headlines!
- *headline*: navigation layer
- *visual*: data layer
- *body text*: annotation layer

also, some practical advice from *Kurt Vonnegut*:
- **Find subjects you care about** - users will be smitten with the way you express things that truly excite you.
- **do not ramble** - your excitement can become too much.
- **keep it simple** - when the display is simple, it makes the user's brain get to work!
- **have the guts to cut** - if it is not functional, just leave it out!
- **sound like yourself** - be true to who you are, that makes you more *trust-worthy*.
- **say what you meant to say** - be clear and honest.
- **pity the readers** - they need us to be patient and willing to simplify and clarify everything.

---

### *How can i apply Editorial Thinking for story telling?*
In order to tell a story, we apply **editorial thinking** to frame and angle the story in the best way. The method consists of the following steps:
- **editorial thinking** is about choosing what to leave out for a particular story.
- **data is encoded** is about all the design choices made when making the visualization.
- **navigation** is about organizing the visual elements.
- **sequencing** is about forming a narrative throughout the visuals.
- **annotation layer** is about highlighting and explaining the data.

For a data story it is important to consider the particular choices in terms of:
- **angle** - what view of the data is best at conveying the message? do you need more? less? 
- **framing** - what to include / exclude to create a representative visual?
- **focus** - what do you want to emphasize?

Common **angles** are:
![](pictures/story_angles.PNG)

---

### *Story telling; do's and dont's*
For **headlines**:
- Keep *Typography* simple to read.
- Emphasize by *bolding* or *size*.
- Remember, 'one in three' is easier to envision than '33%'
- Headlines phrased as *questions* automatically spawn a *call-to-action* response in our minds.

Design for your **audience**:
- remember that *all users are unique*!
- *Don't be your own audience* - test our your visualization on a representative of the target audience.

We want to create **engagement**:
- engagement via *empathy* is about emphasizing with some type of self-made character in your head, representing a part of the story.
- engagement via *curiosity* is essentially audience-centered QA sessions they have with themselves in their head. (includes phrasing headline as question)
- engagement via *make-a-guess* allows the reader to display their world-view and compare it to the data.

---

### *How do I make my visualization memorable?*
*"tell me, and i'll forget. show me, and i might remember. involve me, and i'll understand!"*

When given facts in sequential order, displaying some type of *cause-effect* (causality) either fact will be easier for you to remember than if they were non-connected.

---

### *What makes a good data analyst?*
There was a quote in the slides: *Good analysts are humble storytellers*. 
This essentially specifies to be aware of biases and limits of interpretations. A humble analyst will tell you about several different interpretations and still encourage you to explore on your own, but reminding you that there are limits to the data.


























---
---

## **Part VI - Fall-pits of Data Viz**
- Lectures: 11-12
- Chapters: 3
- Cheat Sheet: Spot_Lying_Charts.pdf

---

### *Why is handling uncertainty important?*
Whenever we have observations (data), we will never be able to establish the exact truth, because there may exist many unknown factors impacting the data upon our knowledge. 

Because much of what we do is based on working with a data-driven approach, which infers trust in the insights, we also need to be truthful with whatever uncertainty exists in our data.

---

### *What are the main sources / reasons for uncertainty?*
There are three main sources of uncertainty in data visualization;
- **Sampling Uncertainty** - the uncertainty stems from data collection proces / sampling.
- **Modelling Uncertainty** - the uncertainty stems from models based on the data.
- **Visualization Uncertainty** - the uncertaintyu stems from the visualization proces / choices.

Each of these sources impact each other, as uncertainty in sampling will impact whatever you model or visualize... On the other hand we might also consider the main reasons for uncertainty to arise;
- **Aleatoric Uncertainty** - uncertainty arises due to *randomness*, which is something we cannot control.
- **Epistemic Uncertainty** - uncertainty arises due to *lack of knowledge*, as we are not ever-knowing beings.

---

### *How do we encode uncertainty?*
Whenever our results are uncertain we want to ensure that the viewer is aware of this, and does not warrant too high trust in the displayed results. But how do we describe / show the uncertainty?

For **probabilistic** approaches we might consider defining a *confidence interval* and show it of... But beware, as people often view them as areas and infer greater area -> better.... (hurricane cone example -> they think the hurricane will grow, but it is just more uncertain where it will be...)

Here is a list of practical **aproaches**:
- *no direct quantification* / *obscurity* (sketchy rendering, lower in the visual hierarchy) - we simply choose a chart that is perceived as less precise... 
    - pros: the viewer is cautious in making inferences.
    - cons: the viewer does not know how much uncertainty is involved. 
- *confidence intervals* - We simply display a margin of error to make it understandable to the audience that it is not bullet-proof prediction.
    - pros: intervals are widely understood, and can be customized to the use-case
    - cons: often the interval is ignored and the focus is on the trend line... also, people might likely interpret it wrongfully.
- *probability density map* - We display the entire range of possible observations
    - pros: usually intuitively understood
    - cons: viewers might not understand in relation to probability, and makes it hard to draw out any particular probability.
- *arrays of icons* - coloring icons 
    - pros: more self-explanatory and allows quick estimates.
    - cons: can only display a single probability.
- *multiple samples in space* / *distributions* - we decide on a certain number of samples, and create something slightly similar to a distribution function.
    - pros: we can choose the number of samples for a certain degree of detail.
    - cons: sampling includes imprecision and it might be hard to make estimates.

---

### *How do humans perceive numbers / words?*
It is important to consider that using **probability language** is a subjective proces, and the exact amount of certainty associated with given words will be different for every single person. 
This includes words / phrases like; *highly unlikely*, *improbable*, *we believe* & *almost certainly*.

We should also remember that thought processes inside our brains always try to simplify the **numbers** we see to statements. 
F.ex. whenever we see a probability higher than 50% for winning, we will usually establish that we are likely to win. In this case even 51% vs. 49% will make you entirely more confident in option one, even if it was 50% vs 50% a week ago.

So how can we **visualize percentages**? Well, we can draw on conventions understood by the majority of the public - f.ex. a theater seat filling or a dart board.

---

### *What is graphicacy?*
Graphicacy is about designing for your viewer's visual literacy - i.e. how to make the viewer obtain the correct interpretation of what you are presenting, using visual cues that they understand.

Graphicacy is defined as **the ability to use and understand a graph** as well as **designing useful graphs**.

---

### *Tell me about cognitive biases*
We live in a world that is unpredictable, and evolution has given us a few bugs to help us survive... But in search for truth, we need to be aware of them to avoid fooling ourselves. The bugs are:
- The **patternicity** bug (*apophenia*) is about *finding patterns everywhere* even if all logic would tell you it might just be coincidences. 
    - Even looking at random events that we KNOW are uncorrelated, our minds will start to wander and find patterns that look slightly convincing. Th elonger we look, the more correlated we will think it is.
    - **Illusory correlation** is about fooling ourselves into seeing correlation that is not there...
- The **continuity bias** is about mentally forecasting development smoothly. Directional signals are strong and naturally convincing.
    - If we see an upward trend, we will expect it to smoothly follow the upwards trend going forward, even when most often it will round off and become straight.
- **Narative Bias** we use patterns and continuity to tell a story about causality between trends. This bug helps us understand impact, but can also be misleading when there are no causal links present.
- **Confirmation Bias** is very well-known within science for fooling one-self, as we will only accept proof of our opinions and world view being correct, ignoring any proof of the opposite. I.e. we try to confirm our beliefs instead of being critical towards our world view.
- **Simplicity bias** is about preferring simpler stories over the complex ones - we want any explanation to be as simple as possible, but the world is way more complex than that!
- **Rationalization bias** is about creating additional reasoning for unexpected / unacceptable events - such as errors of a model being correlated etc. 
    - It is mainly used to *compensate* for errors and *reinforce* the strength of our arguments.
- **Moral Blindness bias** is about not wanting to be held accountable for our biases. We do not want the entire truth continuum heavy on our shoulders.

---

### *What types of lies can i tell in a visualization?*
The first type of lies are **lies of omission**, which is when we oversimplify / remove important data... within this there are several types:
- *only show 1-2 data points* - this is oversimplified, and does not give much context or possible insights. Any time we have a single summary metric we lose a lot of information about local variance.
- *reducing information* - oversimplifying until your data fits your point is misleading to the viewer.

But there are many fall-pits where we might accidentally lie to the viewer do to factors such as:
- **Knowledge Gaps** - there is difference in the amount of background knowledge / how good we are at interpretting a visualization - *visual literacy*, *numeracy*, *visual vocabulary*
- **Media / Societal Shifts** - there is difference in the way we perceive the world / what perspective we come from
- **Bugs in our minds** - there is an abundance of bugs and biases that will impact how we interpret everything around us - *patternicity*, *storytelling*, *confirmation*
- **Truth in numbers** - data and visualizations are often seen as "proof-of-concept", and therefore also believed to be more truthful.

---

### *What are 15 methods of deception?*
Here we will shortly go through methods of deception that we might utilize to untruthful, or just simply things to be aware of when designing / reading charts. One can also view the cheat-sheet Spot_Lying_Charts.pdf.
- **Axis Truncations** - is when the null-point of our axis is different from 0.
    - Completely unacceptable for charts relying on *area* or *height* (i.e. bar charts, area chart),
    - OK for line charts, but beware that it still *exaggerates* the differences.
- **Dual Axes** - is when we have two data sequences with their own axis.
    - Might offer false expectation of causation / correlation (especially if they are on different scales or use truncation)
    - If used, ensure that there is no truncation and scales are comparable and properly labeled!
- **Limited Scope** - is when we remove too much context data
    - Danger is that we enhance a particular subsection too much, producing less truthful understandings of reality than were possible.
- **Concealing a point in the mass** - is when we include too much data, so the point disappears.
-  **Binning choices** - is when we decide on too few or too many bins, so that the details are washed out or hard to distinguish.
- **Seing only in absolutes** - is when we forget to work in ratios for f.ex. choropleth maps to not just become population maps! (which they will if we work in absolutes...)
- **Part-to-whole not adding up** - is when the total of the parts does not equal the whole... This is a very strange phenomena that should be considered gravely misleading!
- **Cheating area and dimension** - is when we use different shape / area conventions for the same sttributes. Perception of area is very different, and thus might mislead viewers.
- **Using cumulative charts** to hide trends - is when we transform our data, ignoring the trends in the native data.
    - f.ex. a decreasing trend made into a cumulative will make it seem like it is increasing instead!
- **Being too smooth** - is when we smooth out curves, but this hides the knowledge awarded by every single data point on their own!
- **Area sized by single dimension** - i.e. circle sized using radius or square by sidelength.... but are is then quadrupled when it is supposed to only be doubled.
- **Extra dimension just because** - is when we add a 3D element for design purposes or similar. This should only be done with f.ex. interactive maps or things where it bring undeniable insights.
- **Deterministic Headlines** - is when we describe the data as an all-knowing entity and an *absolute truth*, which it is not!
- **Comparing aggregates** - is when we compare an aggregate measure of f.ex. performance, but it is a vast simplification. Rather, we should compare distributions or at least add confidence / standard deviation interval.
- **A number alone is meaningless** - is when we present a single number as an insight. A single number might offer a quick overview, but the single number in itself offers us no insights at all.
- **Number decoration** - is when we take a single number and make it significant by making it into a visual.
---

### *Can you give me a short introduction to the Truth Continuum?*
The absolute truth is unobtainable, as we as humans are inherently fallible. 
Something one would be able to obtain is increasing the level of thuthfulness to allow a higher degree of truth and moving closer to absolute truth. See here a distribution of model with truncated timeline:
![](pictures/truth_continuum.PNG)

- *All models are wrong, but some are useful*

This is an important mantra to remember, since (in the search for truth) we will never observe a completely correct model, but we will be able to come up with a good  estimate!

- *Compared to what?*

An single number is not worth a dime, we need to put it into context and perspective before it can make a difference in how people perceive the world. Temporal changes, part-to-whole.... all depends on your task!

This can be done by **increasing depth**, which entails going into more detail with the phenomena you are investigating / trying to make a statement for.
Otherwise it can be done by **increasing breadth**, which entails examining extratenous factors that might affect the phenomena you are investigating.
Both might help in making a visualization more insightful for the viewer.

---















# Highlights
## *Overview First, Zoom and Filter, Details on Demand!*
---
## **What are the 5 qualities of a good visualization?**
The 5 qualities as defined by *Enrico Bertini*:
- **Truthful**: A visualization that is honest and truthful, is not trying to mislead you (intentionally or unintentionally). Do not hide data, excessively summarize data and be aware of your own perception and bias. Apply *critical thinking* whenever you sort, filter and display data!
- **Functional**: A visualization that is functional, will help the audience interpret the data correctly. We want to show our points in a way that the brain can easily understand, *purpose* is the focus.
- **Beautiful**: A visualization that is beautiful, will be interesting to the audience and make them more motivated to spend time interpretting it. Beauty is *subjective* and out goal is therefore designing to be *experienced as beautiful by as many people as possible*.
- **Insightful**: A visualization that is insightful, will clear the path to making valuable discoveries. Visualizations are not just pictures, they need to award us new knowledge. Consider:
    - *Spontaneous Insights*: You see it right away; "a-ha" moment.
    - *knowledge-building insights*: gradual process of exploration to build knowledge.
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
- **Remember the rules of thumb**: at max; 5 lines, 10 bars, 7 slices and 8 colors!

---

## **What are Normans 4 design principles?** 
Design principles are unique to each organisation and to each visualisation designer. Thus this is just one suggestion making some good points:
- **Affordances**: A good design ensures that the intended actions are easy to see, while unintended actions are hidden. Affordances are *all possible actions*!
- **Constraints**: Ensure fewer errors by the user by constraining unintended actions to become impossible!
- **Conceptual Models**: Our minds get frustrated when we have to learn how to use a seemingly arbitrary tool / object.
- **Feedback**: Any design needs to give some sort of feedback to allow the user to know something changed following their action - pushed a button, changed a slicer etc.

**Rule of Thumb**: If you need a sign to tell the user how to use it, the design is ineffective!

---

## **What is the Von Restorff effect?**
The Von Restorff effect describes, that the item that *stands out* is the most likely to be remembered by the user. This might f.ex. be a button that is bright blue while everything else is gray, or a highly saturated bar in a bar chart where everything else has soft colors. I.e. it *draws attention* and creates a *meaningful memory* for the user.

---

## **How can i apply Editorial Thinking for story telling?**
In order to tell a story, we apply **editorial thinking** to frame and angle the story in the best way. The method consists of the following steps:
- **editorial thinking** is about choosing what to leave out for a particular story.
- **data is encoded** is about all the design choices made when making the visualization.
- **navigation** is about organizing the visual elements.
- **sequencing** is about forming a narrative throughout the visuals.
- **annotation layer** is about highlighting and explaining the data.

For a data story it is important to consider the particular choices in terms of:
- **angle** - what view of the data is best at conveying the message? do you need more? less? 
- **framing** - what to include / exclude to create a representative visual?
- **focus** - what do you want to emphasize?

Common **angles** are:
![](pictures/story_angles.PNG)

---

## **What are the main sources / reasons for uncertainty?**
There are three main sources of uncertainty in data visualization;
- **Sampling Uncertainty** - the uncertainty stems from data collection proces / sampling.
- **Modelling Uncertainty** - the uncertainty stems from models based on the data.
- **Visualization Uncertainty** - the uncertaintyu stems from the visualization proces / choices.

Each of these sources impact each other, as uncertainty in sampling will impact whatever you model or visualize... On the other hand we might also consider the main reasons for uncertainty to arise;
- **Aleatoric Uncertainty** - uncertainty arises due to *randomness*, which is something we cannot control.
- **Epistemic Uncertainty** - uncertainty arises due to *lack of knowledge*, as we are not ever-knowing beings.

---

## **Tell me about cognitive biases**
We live in a world that is unpredictable, and evolution has given us a few bugs to help us survive... But in search for truth, we need to be aware of them to avoid fooling ourselves. The bugs are:
- The **patternicity** bug (*apophenia*) is about *finding patterns everywhere* even if all logic would tell you it might just be coincidences. 
    - Even looking at random events that we KNOW are uncorrelated, our minds will start to wander and find patterns that look slightly convincing. Th elonger we look, the more correlated we will think it is.
    - **Illusory correlation** is about fooling ourselves into seeing correlation that is not there...
- The **continuity bias** is about mentally forecasting development smoothly. Directional signals are strong and naturally convincing.
    - If we see an upward trend, we will expect it to smoothly follow the upwards trend going forward, even when most often it will round off and become straight.
- **Narative Bias** we use patterns and continuity to tell a story about causality between trends. This bug helps us understand impact, but can also be misleading when there are no causal links present.
- **Confirmation Bias** is very well-known within science for fooling one-self, as we will only accept proof of our opinions and world view being correct, ignoring any proof of the opposite. I.e. we try to confirm our beliefs instead of being critical towards our world view.
- **Simplicity bias** is about preferring simpler stories over the complex ones - we want any explanation to be as simple as possible, but the world is way more complex than that!
- **Rationalization bias** is about creating additional reasoning for unexpected / unacceptable events - such as errors of a model being correlated etc. 
    - It is mainly used to *compensate* for errors and *reinforce* the strength of our arguments.
- **Moral Blindness bias** is about not wanting to be held accountable for our biases. We do not want the entire truth continuum heavy on our shoulders.

---

## **What are 15 methods of deception?**
Here we will shortly go through methods of deception that we might utilize to untruthful, or just simply things to be aware of when designing / reading charts. One can also view the cheat-sheet Spot_Lying_Charts.pdf.
- **Axis Truncations** - is when the null-point of our axis is different from 0.
    - Completely unacceptable for charts relying on *area* or *height* (i.e. bar charts, area chart),
    - OK for line charts, but beware that it still *exaggerates* the differences.
- **Dual Axes** - is when we have two data sequences with their own axis.
    - Might offer false expectation of causation / correlation (especially if they are on different scales or use truncation)
    - If used, ensure that there is no truncation and scales are comparable and properly labeled!
- **Limited Scope** - is when we remove too much context data
    - Danger is that we enhance a particular subsection too much, producing less truthful understandings of reality than were possible.
- **Concealing a point in the mass** - is when we include too much data, so the point disappears.
-  **Binning choices** - is when we decide on too few or too many bins, so that the details are washed out or hard to distinguish.
- **Seing only in absolutes** - is when we forget to work in ratios for f.ex. choropleth maps to not just become population maps! (which they will if we work in absolutes...)
- **Part-to-whole not adding up** - is when the total of the parts does not equal the whole... This is a very strange phenomena that should be considered gravely misleading!
- **Cheating area and dimension** - is when we use different shape / area conventions for the same sttributes. Perception of area is very different, and thus might mislead viewers.
- **Using cumulative charts** to hide trends - is when we transform our data, ignoring the trends in the native data.
    - f.ex. a decreasing trend made into a cumulative will make it seem like it is increasing instead!
- **Being too smooth** - is when we smooth out curves, but this hides the knowledge awarded by every single data point on their own!
- **Area sized by single dimension** - i.e. circle sized using radius or square by sidelength.... but are is then quadrupled when it is supposed to only be doubled.
- **Extra dimension just because** - is when we add a 3D element for design purposes or similar. This should only be done with f.ex. interactive maps or things where it bring undeniable insights.
- **Deterministic Headlines** - is when we describe the data as an all-knowing entity and an *absolute truth*, which it is not!
- **Comparing aggregates** - is when we compare an aggregate measure of f.ex. performance, but it is a vast simplification. Rather, we should compare distributions or at least add confidence / standard deviation interval.
- **A number alone is meaningless** - is when we present a single number as an insight. A single number might offer a quick overview, but the single number in itself offers us no insights at all.
- **Number decoration** - is when we take a single number and make it significant by making it into a visual.
---

## **Can you give me a short introduction to the Truth Continuum?**
The absolute truth is unobtainable, as we as humans are inherently fallible. 
Something one would be able to obtain is increasing the level of thuthfulness to allow a higher degree of truth and moving closer to absolute truth. See here a distribution of model with truncated timeline:
![](pictures/truth_continuum.PNG)

- *All models are wrong, but some are useful*

This is an important mantra to remember, since (in the search for truth) we will never observe a completely correct model, but we will be able to come up with a good  estimate!

- *Compared to what?*

An single number is not worth a dime, we need to put it into context and perspective before it can make a difference in how people perceive the world. Temporal changes, part-to-whole.... all depends on your task!

This can be done by **increasing depth**, which entails going into more detail with the phenomena you are investigating / trying to make a statement for.
Otherwise it can be done by **increasing breadth**, which entails examining extratenous factors that might affect the phenomena you are investigating.
Both might help in making a visualization more insightful for the viewer.

---


















# Group Presentation
## Storyline
- what data you used

We use data from [ergast](http://ergast.com/mrd/), in the form of data sourced from [kaggle](https://www.kaggle.com/datasets/rohanrao/formula-1-world-championship-1950-2020?resource=download) and the [FastF1 API](https://docs.fastf1.dev/) for python. 
The data source contains detailed historic information on F1 races; Event data (overall results) and lap data (on driver level).

If we had more time / data available we would have investigated weather aspects in more depth.

- what you wanted to communicate

We wanted to communicate how Kevin Magnussen got his first ever pole position, in an inferior car. We try to tell a story of previous grand prix performance on the same track as well as qualifying in the season. This is to set the stage for why it was unexpected.

Then we examine the qualifying session in particular and the lap in detail, to show possible factors affecting lap times as well as how Magnussen performs in comparison to Verstappen on their best laps.

- why you chose the specific visualization technique

We chose to create a storyline targetting F1 fans, to have details in both broad and narrow perspectives.
We chose a line chart as the entry point to allow easy comparison in the temporal space, and highlight Magnussen for *popout* channel effectiveness.

---
## Viz 1
### Buzz Words
- **Line Graph** (Chart) - easy comparability over time. 
- We used **line thickness** to highlight Haas in 2022. 
    - pre-attentive attribute *size*/*line width* to be effective in the *popout* channel
- We **shaded** the race that was cancelled for tranparency.
- **Colors** are chosen based on official team colors (slightly modified).
- We **filtered** constructors to only those participating in 2022 to reduce noise.
- We **filtered** to solely the best qualifying position for each constructor to show best performance for the TEAM. (also; average wouldn't work for the intended *insight*)
- We placed **team labels** next to the line in same color, for ease of reading the chart.
- The **axes** is reversed, to support intuition of *lower is better* (i.e. higher up on chart = better).

### Fall-pits
- In 2022 **new cars** were used, maybe that affected the data / distributions.... oh wait, but that's why we have plot 2!
- The way we display **race cancelled** might be a bit too noisy - but it works for allowing the eye to follow the line. (Future -> would remove shaded area w. text, but text provides context...)
- Why did we not shade some constructors in gray, and further **highlight** Haas & Redbull? Well, we could and we discussed it, and ended up deciding on using official colors due to it being 
    - the entry point and the focus of this plot being both context and sparking interest in Haas. 
    - Also, fans of other teams might analyze the plot from their team's perspective, and then be interested in the thickness-highlight.
- Why do you show data specifically from 2016 going forward? That's when **Haas joined**!

---
## Viz 2
### Buzz Words
- **Bar plot** - horizontal orientation. (we are used to read from left to right and top to bottom)
- Bars are **sorted** to have the best performing driver at the top.
- We chose to not include **numbers** (in tooltip though, if you wanna see!) to reduce clutter. The *task* for this chart is mainly to visually see the 'usual' position of drivers in the season.
- We placed the driver **labels** inside the bars to reduce noise and ease association.
- We **highlight** Verstappen and Magnussen with the official "fastest lap"-color and a bold text, coloring all other drivers in gray.
    - We focus on *pre-attentive* processing attribute and highlight with a neon color.
- We **keep** all the other drivers to provide *context*.

### Fall-pits
- Your **storyline** kinda falls short here, as the color coding is not consistent, and it would require knowledge of Formula 1 drivers / constructors.
    - That is true, and something we didn't realise at the point of designing. If we were re-designing it today, we might want to include teams in the *tooltip* or use *different highlight colors* (blue and black or similar).
    - They are highlighted with *equal weight* in the current color scheme.
- We might've wanted to **move the x-axis** to the top as we are focusing on the top half! 
- Why the fuck do you have **grid lines**? For easier comparison by eye-measure (precision by eye -> further precision is awarded by tooltip)

---
## Viz 3
### Buzz Words
- It's a **timeline**.
- We **colored** data points and the line itself, following intuitive color palettes similar to previously described, which is the most intuitive colors for the target audience. 
    - Line is green / red following track status. These colors are intuitive following flags and general traffic light conventions.
    - We are utilizing *cultural associations/conventions* of viewers.
- **Track Temperature** is only showed particularly at one point in time, but is in the tooltip wherever available.
    - Data point is for drawing attention
    - Tooltip is to allow exploration
    - currently we only have boolean on rain, which is much simplified!
- We have **labels** to give descriptive understanding of each event.
- **labels** are colored in colors corresponding to the point.
- We mark an item with a **point** - we might have benefitted from using a line instead, as it is only a timestamp and not a time period.... 
    - BUT! it is an overview, and we chose a point to draw attention (Tooltip has exact timestamp if precision is needed)
- We **offset labels** (some are further form the timeline) to allow for reading labels without a horizontal shift.


### Fall-pits
- Why did you choose **timestamps**? -> we might benefit from normalising x-axis to have Q3-start as 0 and time differences.
- **Track Temperature** might have been more easy to analyze in a seperate plot... (Rain too, if we had data...)
- Could you have plotted lap times in a different way in this plot?
- Why is **Q3 End pink**? this is the point in time where it is finally decided which lap time has been fastest. *Alternative*: red to indicate no more driving, checkered to match corresponding flag.
- **labels** are understandable by target audience, could you have chosen different labels to allow a broader audience? Yes, OR add explanations of racing terms :D

---
## Viz 4
### Buzz Words
- We have an **animation** of the fastest laps of MAG and VER.
- We visualize their travel on the **track** to give the viewer the context of turns and straight stretches.
- We compare just MAG & VER, because MAG beating VER is the *unlikely* event we are interested in analyzing. VER was otherwise the fastest on the track.
- We chose **dots** to visualize drivers, and made dots bigger then the track for ease of following them with the eye.
- we **colored** dots/areas in their corresponding team colors (to tie together with plot 1 & 3)
- We added an **area plot** to function as 'history' of the laps, to assist analysis for the viewer. The area plot is also **animated** because of functioning as a trace.
- We chose the **difference measure** to be meters, because it directly relates to the distance seen between points on the track animation.
    - we didn't choose seconds because timestamps are unaligned. Also, time is more abstract to envision than distance in a mental picture.

### Fall-pits
- What if I wanted to analyze MAG against a different driver?
- Why is it an area plot? Area plot might mislead people, as the total area under the plot in each color does not correspond with the final result of the race.
    - It is **one version of the truth** as it is clear that Verstappen was ahead most of the lap.
    - With a **line plot** it was not clear which driver was ahead. 
- Why is your axis where it is?
    - We might want to switch it over to the right, because the end result is what we are interested in as a final result.
- We might want to flip the colors so the color would indicate *who is ahead* -> *who is the fastest*...