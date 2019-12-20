# CaiAptitudeAssessment
Trio of coding challenges done for a prospective employer.

1.  For the first task, I wrote a console application which included an onscreen menu of options, which correspond to each of the required challenges of task 1
2.  For the second task, I wrote a basic Web Form, who's events trigger the calling of Spotify's public APIs to search for a given music artist and their collection of albums, all of which are returned and displayed in a data grid 
3.  For the third task, I wrote another console application, which simply describes the problem and displays the on-screen solution

### Task 1  - Basic Problem Solving
Using your favorite .NET programming language, please solve the following logic problems in a single program (executable): 

- Take any sentence in a String and reverse every word:

   Example Input:
 `The quick brown fox jumps over the lazy dog`

 Example Result:
`dog lazy the over jumps fox brown quick The`

- Define two Integer (32bit) variables and values of X=72 and Y=59, now swap the values of X and Y without declaring any new variables, use only the two existing X and Y variables.

 Example Input:
 `X = 72`
 `Y = 59`

 Example Result:
 `X = 59`
 `Y = 72`

- Find the pattern `[Number1, Number2]` in any given String and get the Integer (32bit) values for Number1 and Number2.

 Example Input:
`Foo Bar [45,66] Bash`

 Example Result:
 `Number1 = 45`
 `Number2 = 66`

### Task 2  - Consuming a public web service

A web developer wants to include music search capability on his web site. He would like user to be able to enter an artists name and have the artists five most popular albums to be shown in a grid below. In order to achieve this, you must make a call to the Spotify web API to return the desired data.

You will need to register for a Spotify account if you dont have one (free or paid). The base web service located at:

https://api.spotify.com

There is a list of all available endpoints on https://developer.spotify.com/web-api/endpoint-reference/ but the following ones will probably be the most helpful:

Search for an artist:
`/v1/search`

Get several albums:
`/v1/albums?ids={ids}`


Please construct an ASP.NET web page that will consume this web service and will allow the user to enter an artist’s name, and display his or her albums below.

###Task 3 - Encryption / Decryption
Using your favorite .NET programming language, decrypt a TripleDES Encrypted, and Base64 encoded String. This portion of the task is absolutely optional and is only supplied to observe the candidate’s way of solving and approaching a complex problem.

Encryption Algorithm: `TripleDES`
TripleDES KeySize: `128`
TripleDES Key: `“0123456789ABCDEF”`
TripleDES Initialization Vector (IV):`“ABCDEFGH”`

Encrypted and Base64 Encoded Input:
`ABvAsOKcGXqc5uQ4O5Z53isJaH31Pa8+PeddljE4mSU=`

Decrypted Result:
The result you should provide is the clear text version of the above TripleDES encrypted then Base64 encoded String.
