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

![](figures/qualitative_risk.PNG)

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
- *Seperation of Responsibility*: Split up privilege so no single person/device has complete power of a process and accesses.

## Part I - Security
### *What is all this "adversarial mindset" about?*
Often when designing or developing items or goods, we are mostly interested in what an item/service can do; i.e. we are interested in the *intended* use-functions of an item that solve some problem or challenge that we face. 

Something we forget, is that there might exist a bunch of unintended functionalities that we have not considered, that might pose a threat to security. Think about the example of airtags, and how they might be used to stalk people after slipping it in their belongings. 

The **adversarial mindset** is about thinking the way an attacker would, as to prevent harmful unintended functionalities, such that what we built can not be abused by a possible attacker with malicious intent. This includes considering:
- *Assets*: Things the attacker might want to get ahold of.
- *Capabilities* and *goals*: What do we expect the attacker to be capable of? How should we prioritize?
- *Attack vectors* and *tools*: How do we mitigate the risks? what kind of attacks are we likely to be subject to?

### *What is the Cyber Kill Chain?*
The *Kill Chain* is a military concept, which focuses on *advanced persistent threat* models. The main idea is that a threat evolves over several necessary steps, and the defender might break any chain. The main steps of the cyber kill chain are:
- **Reconnaissance**: Collecting information about the target to be used in possible future attacks.
    - There exists both *active* and *passive* recon; i.e. are we actively breaching systems (f.ex. scanning networks) to obtain information, or are we passively intercepting information?
    - We might look up *Common Vulnerabilities and Exposures* (CVE) about identified technologies; These are know faults / leaks in a system that might be exploited.
    - **SQL Injections** is when we use clever tricks, for example a log-in interface utilizing database queries with no projection to ALWAYS let us in by creating a query that returns the necessary value.
    - **Broken Access Control** is when an attacker obtains *privilege escalation* by getting more access than they should have. We might consider several directions of access control:
        - *Vertical*: some users have more rights than other users.
        - *Horizontal*: users have rights to different sections.
    - Open-source intelligence (**OSINT**) is intelligence produced by collectively evaluating and analyzing publicly available information. I.e. it is *passive* and to be used by any individual or corporation. Thus, it might be utilized for both good and bad.
    - One might also use public ressources like krak.dk or tax records, otherwise possibly also leaked data. We need to minimize publicly available sensitive information that might be used for harm!
- **Weaponisation**: Find a way to exploit your entry point of choice!
    - Might be several different methodologies: use a premade exploit, craft an attack yourself, use found credentials to access or plan a *social engineering* attack.
- **Delivery**: Make your exploit reach the intended target. Perform beginning stages needed for the attack.
    - 90% of all cyber attacks begin with an email.
- **Exploitation**: Launch the exploit. We attack!
- **Installation**: Make your presence persistent, such that you can continually exploit the subject.
- **Command** and **Control**: overtake control of all relevant systems and components.
- **Action on objectives**: Steal / Modify / Damage Information!

Many criticise the kill chain for being too high level and not necessarily determining the exact order things would appear in. Alternatives are:
- *Mitre ATT&CK*: 14 tactics and 188 related techniques
- *Unified kill chain*: has 3 high-level stages (in, through, out) and 18 detailed tactics for the stages.

### *What is Cryptography and how is it relevant to the Security Goals?*
Cryptography considers everything surrounding algorithms to encrypt and decrypt information. It is highly relevant to 2 out of the 3 security goals: *confidentiality* and *integrity*.

We might consider several different **Cryptographic Failures**, where the cryptography does not fulfill the security goals:
- *Absence* of Cryptography: We simply did not apply it at all.
- *Insecure Algorithms*: Any cryptography that is broken / home-made, as these can easily be broken by an attacker.
- *Insecure Implementation*: Any omissions / insecure storage of keys / insecure parameters that might violate the security of the encryption.

When we look at cryptography we are considering a communication stream between two people Alice and Bob, and the attacker can intercept the communication between these two with the goal of reading or modifying the message.

The **Cryptosystem** is a set of algorithms that can perform:
- **Encryption**: End(message_text, key) -> cipher_text
- **Decryption**: Dec(cipher_text, key') -> message_text
- **Key Generation**: KeyGen() -> key, key'

### *What is Symmetric Encryption?*
In symmetric encryption the key used to encrypt the message is the same that is used for decrypting the message. The key is secret and known to the people in communication, but the encryption/decryption mechanisms are public. The main challenge of symmetric encryption is that each person needs to store 1 key per communication channel the use, resulting in way too many keys!

Note that this follows **Kerckhoffs' principle**, which states that the algorithms shall not be secret and it should not be a problem if it falls into enemy hands as long as the key is secret. This allows better scrutiny by researchers, and is related to the *Open design Security Principle*.

Some Examples of symmetric encryption is:
- **Caesar Cipher**: One of the most popularly known ciphers, of which the letters of the alphabet are switched by a certain offset.
    - The main *problem* with this cipher is that there are only 26 possible keys (**small key-space**), and thus it can easily be brute-forced!
- **Substitution Cipher**: Here we place all the letters of the alphabet to be encoded by some random permutation. (similar to caesar, yet it is not in-order)
    - Brute-force is no longer an issue, but **language patterns are preserved**! Thus can often be cracked using neat tricks and frequency analysis.
- **One-time pad**: Use a random n-bit string (0-1) and Encrypt / Decrypt using XOR.
    - c = Enc(m,k) = XOR(m_bit, k_bit)
    - m = Dec(c,k) = XOR(c_bit, k_bit)
    - The main *problems* is the the **key length = message length**, and thus it is not suited for file transfers or longer messages. Also, a **key shall never be reused** as this will reveal information about the key and thus allow us to decrypt the message.. yikes!
- **Block Ciphers**: map fixed-size plaintext into fixed size ciphertext through a variety of techniques achieving *non-linearity*. The initialization vectors are changed to avoid problems of key reuse.
    - DES (Broken) is an example of a block cipher
    - AES (Broken for some modes of operation). AES-CBC (cipher-block-chaining) works. other working: CFB (Cipher Feedback), CTR (Counter)

### *What is Asymmentric Encryption?*
Asymmentric encryptions relies on sender and receiver not needing to store the same key, and is largely based on *one-way functions*. 

A one-way function is a function f for which it is easy to calculate f(x) given x, but hard to find x given f(x) = y given y.
Further, a *trapdoor* one-way function is a function with the same characteristics as above, yet following that it becomes easy to find x in f(x) = y given y, in the the case of knowing some secret *d*.

Asymmetric encryption relies on **secret keys** and **public keys** for which *Dec(Enc(m, pk), sk) = m*. 

#### RSA
One prominent example of an asymmetric cryptosystem is RSA. It follows through key generation that the following numbers are generated:
- (s) p is a prime number
- (s) q is a prime number
- (p) N = p*q 
- (p) e is some whole number [1,(p-1)(q-1)-1], fulfilling gcd(e, (p-1)(q-1)) = 1
- (s) d is some whole number same range as e, fulfilling e*d = 1 % (p-1)(q-1)

Now we can define the algorithms for encryption / decryption:
- Enc(pk, message) = m^e % N
- Dec(sk, cipher) = c^d % N 
- Dec(sk, Enc(pk, message)) = (m^e)^d % N = m % N

Note that it is infeasible to find the secret key 'd' given that factoring N for large N is an infeasible problem - this is what ensures the security.

The main **problems** encountered by RSA encryption is when the set of possible m is small: I.e. "Yes"/"No", names from a specific group of people, CPR Numbers.

### *What can you tell me about Hash Functions and their utilization for Integrity?*
Hash functions are one-way functions. For somethign to be a good function it needs to follow a set of minimum requirements:
- **Easy to compute** H(m) given m
- **Pre-image resistance**: Given hashed message h, infeasible to find m with h = H(m)
- **Second pre-image resistance**: Given m1, infeasible to find m2 != m1 for which the hashed message is the same: H(m1) = H(m1)
- **Collision Resistance**: Infeasible to find H(m1) = H(m1) for which m1 != m2

In theory the advantages of using hash functions is that an attacker does not learn any passwords even if database is leaked. BUT! For *known passwords* it is easily reversible, And users with the *same password are easily detectable*.

#### Salt and Pepper
Instead of just hashing f.ex. passwords directly, one might use the salt and pepper method. Here we append the password with salt and pepper, of which salt is a random string connected to the username instance and pepper is a random secret global string used across all passwords.

#### Digital Signatures
Builds upon the idea of asymmetric encryption, using algorithms:
- Sign(message, sk) -> signed: can only be produced by the sender using their secret key
- Verify(message, signed, pk) -> TRUE/FALSE: Verifies that message and signed have been produced using the secret key associated with a given public key.

### *Tell me a bit about Authentication*
There are three different levels at which we might consider verifying a user trying to access a resource:
- *Identification*: "This is Alice"
- *Authentication*: "This person who claims to be Alice is actually Alice"
- *Authorisation*: "Alice has rights to access the resource"

When we talk about **Authentication** in Particular, we might consider three main groups of authentication methods, and whenever we combine several of these methods we obtain *multi-factor authentication*:
- Something you **know**: passwords
    - Can be brute forced :( also, hard to remember a lot of long strong passwords by heart, thus not very suited for the human brain!
        - *Guessing* attacks: Brute-force, phishing, password recovery security questions
        - *Snooping* attacks: (User-side) Spywareon device (keylogger) of physical space (PW written down)
        - *Sniffing* attacks: (communication-side) attacker observes network communication - USE HTTPS / VPNs!
        - *Server Breach* attacks: attacker gets access to the server doing authentication, thus getting access to all incoming communication.
    - Single Sign-On (SSO): use a single account / identity to authenticate to other services. Does pose potential privacy concerns and poses a *single point of failure*.
    - Secure Shell Protocol (SHH): Harder for the user, requires knowledge of using public and private keys and keeping the private key completely secure.
- Something you **have**: keycard, USB, smartphone
    - Can be stolen / lost and might be forged if not enough safe guards exist (often part of multi-factor)
- Something you **are**: fingerprint, face ID, voice
    - Inherence-based: can be physiological (iris, fingerprint, blood pressure) or behavioral (signature, voice)
    - Often more error-prone (false positives and negatives) - can be spoofed! Also, problematic as these are not "replaceable" in same way as a password or key-card might be!
    - Requires sampling of key features to create a template that best approximates those features.

### *What about Access Control?*
When we combine *Authentication* and *Authorisation* we end with **Access Control**. We might define the allowed accesses on various granularities considering:
- *Discretionary Access Control*: For each user and each resource access rights are defined: very granular, but lacks flexibility!
- *Mandatory Access Control*: Access rights are defined based on a vertical security clearance. Anythign on or below your clearance is visible to you. (Military way)
- *Role-Based Access Control*: Access Rights are associated to each role, and people can be assigned these roles to gain access to relevant resources.
- *Attribute-based Access Control*: Access rights are determined based both on the subject, object and environment; i.e. does this individual who is X need access to Y for which Z and W are true? Very fine-grained!

### *What is threat modelling?*
Threat modelling is a general class of approaches towards security management, and can be used to model and prioritize different threats. the main questions we consider are cyclical as depicted below:

![](figures/threat_modelling.PNG)

#### What are we building?
In this stage we attempt to describe the entire functionality of the system we want to do threat modelling for. This includes describing all:
- **Functionality**: How is the system used?
- **Acces Rights**: Who should be able to do what in the system? (users and trust levels)
- **Assets**: Which entities are held within the system, that might be of value?
- **Data Flow**: What communication paths does the data flow consist of?

#### What can go wrong?
In this stage we are interested in coming up with all possible attacks using brainstorming. The most common guided way of brainstorming is **STRIDE**, applied to the system as a whole or individual components:
- **S***poofing*: Violating authenticity by impersonating a user/process/component.
- **T***ampering*: Violating integrity by maliciously altering data
- **R***epudiation*: Violation non-repudiation by denying an action took place (f.ex. student denying taking an exam)
- **I***nformation disclosure*: Violating confidentiality by accessing information without being authorised.
- **D***enial of service*: Violating availability by preventing access to services / data.
- **E***levation of privilege*: User getting access privileges higher than allowed to their role. (Vertical: more rights, horisontal: different rights)

Then one might create an attack tree and use pruning to eliminate threats defined in different branches due to safety measures:

![](figures/attack_tree.PNG)

#### What can we do about it?
At this step we use the **Risk Management** strategies as described elsewhere to model the likelihood of each threat and move threats into a manegable likelihood and impact.

#### Did we suceed?