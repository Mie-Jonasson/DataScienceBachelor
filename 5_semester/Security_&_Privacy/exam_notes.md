# Security & Privacy - Exam Notes
## Part I - Introduction
### *What do we need security and privacy for?*
The reasons for learning abotu security and privacy is largely two-fold. We learn how to protect ourselves, but also how to protect the data that we work with!

When considering protecting data that we work with we need to consider both storage, analysis and data management in general.

### *What are the basic definitions when talking about security and privacy?*
- **Cybersecurity**: "The process of protecting information by preventing, detecting and responding to attacks."
- **Information**: "communication or representation of knowledge such as facts, data or opinions in any medium or form [...], that can be produced, processed or stored by any computer"
- **Attack**: "Any kind of malicious activity that attempts to collect, disrupt, deny, degrade or destroy information system resources or the information itself."

### *What different types of attackers might we consider, and what is their motivation?*
#### Interpersonal
Interpersonal attackers target individuals whom they know. They often lack resources and expertise, but are highly motivated in targeting the specific individual. Examples are cyberstalking, cyberbullying and doxxing.

#### Financial / Organised Crime
Mostly non-personal targeting for high-value payouts. Often done by people with some expertise and resources. using fraud, identity theft or ransomware.

#### Hacktivists
Politically motivated attacks - often differing levels of expertise and levels of motivation.

#### State Actors
State-hired attackers with large amounts of ressources and expertise. Often goal is disrupting critical infrastructure to influence the political landscape in a target region.

### *What are the basic goals relevant to Security?*
- **Confidentiality**: Any information is kept secret and remains secret even with attackers trying to intercept / access.
- **Integrity**: Any information is truthful and not altered / accessed maliciously.
- **Availability**: Information should be readily available for the scope of a system; Attacks might do DoS,
- **Authenticity**: Users are who they say they are.
- **Accountability**: All actions can be traced to the source for remedial counteractions.

### *Why is the attacker-defender relation asymmetrical?*
When we create **security models** we need to think about what we believe an attacker would be able to do, and in this case also discounting protective means under the assumption of what an attacker cannot do. In this way, the defender needs to clsoe off all the ways the attacker might enter the system, while the attacker just ahve to find a single vulnerability and exploit it.

### *What can you tell me about risk?*
No system can be 100% secure against any attack, yet a secure system is secure against all plausible attacks. In order to decide what attacks are plausible and that we would like to protect against we use **Risk Estimation**. We might both use any quantitative measer or a qualitative risk matrix approach, yet the problem arises as both are often subject to uncertainty and complexity.

Once we have estimated the risk posed by each identified threat, we might utilize some of the following **Risk Management Strategies**:
- *Mitigate*: We mitigate (lessen) som of the risks, i.e. reduce likelihood and impact. Might be costly in some cases.
- *Accept*: If the impact and likelihood are both small, then we might just accept that the threat exists. It might be too costly to do anything, yet liability issues remain in this case!
- *Avoid*: Avoid having the risk manifest itself in the first place; i.e. worried about data leakage -> do not store any data.
- *Transfer*: Pass the security concerns on to another vendor / person. Thus, the threat will be on their account to be protected.

### *Can you name-drop the most important security principles?*
- *Security by Design*: We ensure security is in place throughout development.
- *Fail-safe Defaults*: Default settings should always be the most secure ones.
- *Complete Mediation*: Related to zero-trust, ensure that all accesses to any object is checked.
- *Open Design*: Design can be openly scrutinized and security does not rely on secrecy of protection mechanisms.
- *Least Privilege*: Any user or device should only have the minimal required accesses for their role
- *Defense in depth*: Avoid a single point of failure.
