# Address Extractor API Documentation

The Address Extractor API has been designed inline with SOA and Domain Driven Design(DDD) to provide an address extraction feature from an accurate multiline address for a specific well known country. As for now CANADA has been listed as well known country and for other country's address, a generic extractor will be used to extract the address.

## API Solution Architecture

DDD approch has been used for designing the architecture of the solution by clearly segregating the each responsibility with clear structure.
 - **AddressFinder.Common** : Responsible for holding all the common functionality/constants of the solution. 
 - **AddressFinder.Domain** : Responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. This layer is the heart of our solution.
 - **AddressFinder.Infrastructure** : Responsible for how the data that is initially held in domain entities (in memory) is persisted in databases or another persistent store. As of now we have all the extraction logic stored here.
 - **AddressFinder.Tests** : Responsible for mirroring the structure of the code under test. **_TODO_:** *Test cases needs to be done*
 - **AddressFinder.WebApi** : Responsible for defining the jobs the software is supposed to do. This layer should be used to communicate for extraction logic.
