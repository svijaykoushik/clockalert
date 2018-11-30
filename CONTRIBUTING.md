First, Thank you 🙏🏽  for contributing to Clock Alert. 👍🏽

Please read the [Code of Conduct](CODE_OF_CONDUCT.md) before contributing to the project

### Table of contents

[How do I contribute to Clock Alert?](#How-do-I-contribute-to-Clock-Alert?)

[How do i report a bug?](#How-do-i-report-a-bug-🕷?)

 * [Guidelines to create a ticket](#Guidelines-to-create-a-ticket)

[How do i suggest a feature request or enhancement?](#How-do-i-suggest-a-feature-request-or-enhancement📜?)

 * [Guidelines to submit a feature request](#Guidelines-to-submit-a-feature-request)

[Code contribution](#Code-contribution-👨🏽‍💻)

 * [Before getting started](#Before-getting-started)
 * [Cloning the repository](#Cloning-the-repository)
 * [Setting up the development environment](#Setting-up-the-development-environment)
 * [Guidelines to create a commit](#Guidelines-to-create-a-commit)

## How do I contribute to Clock Alert?

There are several ways to contribute to Clock Alert project.
1. You can report a bug or an issue in the functionality by opening a ticket in the tickets section.
2. If you have an Idea 💡  that can improve and enhance this project then you can create a discussion and make your suggestion in the discussion forums.
3. If you want to fix a bug, then clone the source repository, fix it and create a merge request.

## How do i report a bug 🕷?

1. Head to the Clock Alert [project page](https://sourceforge.net/projects/clockalert/)
2. On the [tickets section](https://sourceforge.net/p/clockalert/tickets/) click Create ticket.

### Guidelines to create a ticket

1. Name of the ticket should be clear and on the point.
2. Mention the version number of the app. This is mandatory.
3. The bug should be explained clearly.
4. Steps to recreate the bug is mandatory.
5. Set the label as bug.

## How do i suggest a feature request or enhancement📜?

Your new ideas for enhancement of this project is very helpful for its development. Feature requests can be made in the ["Feature Request" forum](https://sourceforge.net/p/clockalert/discussion/featreq/) on the Discussion section of the project page.

### Guidelines to submit a feature request

1. Place the name of the feature with suffix feature request in the topic heading
2. Explain clearly about the new feature.
3. Also explain how it would be of use to you and others.

# Code contribution 👨🏽‍💻

## Before getting started

Clock Alert project is being developed in C# language of the Microsoft .NET framework. So a basic knowledge in C# is required for code contributions. The entire project is stored in a single "Git" repository which means Git is being used as the project's version control software. So, a basic knowledge in Git Clone, Git Push, Git Pull and other operations is required.

The following software will be required to be installed before hand. These software are suggested on the assumption that your development machine is a windows machine.

1. Git for windows.
2. Visual studio (Express edition is not preferred).
3. GitHub Desktop (optional)

## Cloning the repository

### Using command line interface (CLI)

1. Open cmd and change the location to a known location.
2. Type in the command 
   1. Using SSH 
   
          git clone ssh://moon01man@git.code.sf.net/p/clockalert/code clockalert-code
   2. Using HTTPS 
   
          git clone https://moon01man@git.code.sf.net/p/clockalert/code clockalert-code
3. Now, wait till the repository gets cloned. It may take several moments to complete the action.

### Using GitHub Desktop
Instructions are based on GitHub Desktop Version 1.4.3

1. Click **File** > **Clone repository** or press **Ctrl + Shift + O**
2. The **clone repository dialog** opens
3. In it, select the **URL tab**
4. Enter the following in the **URL box**.

         https://moon01man@git.code.sf.net/p/clockalert/code clockalert-code    
5. Choose a known and convenient location in the **local path** box
6. Finally, click the **Clone button** to clone the repository.

## Setting up the development environment

Add the cloned repository to Visual Studio 

1. On the menu, choose **File** > **New** > **Project From Existing Code**. 
2. In the **Create Project from Existing Code Files wizard**, choose the project type as *Visual C#* in the **What type of project would you like to create?** drop-down list box, and then choose the **Next** button. 
3. In the wizard, Type in *Clock Alert* as the **project name** and select *Windows Forms Application* as **Output type**  in the **Specify the details of your new project** section.
4. Choose the directory where you've cloned the repository in the  **Where are the files?** section and choose **Finish** button to create the project.

## Guidelines to create a commit

1. Enter a short message of the changes made
2. Enter a detailed description of the changes made and the files changed and the reason for changing.

   Example 
    
       git commit -m "Short message" -m "Detailed description of changes"