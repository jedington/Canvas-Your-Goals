<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** github_username, repo_name, twitter_handle, email, project_title, project_description
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Twitter][twitter-shield]][twitter-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/jedington/Canvas-Your-Goals/">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Canvas Your Goals</h3>

  <p align="center">
    An MSSA 18-week project + continued afterwards (because why not)
    <br />
    <br /> 
    <a href="https://visionboardjedington.azurewebsites.net/">View Demo</a>
	·
    <a href="https://github.com/jedington/Canvas-Your-Goals/blob/master/docs/Canvas-Your-Goals-Wireframe.pdf">Wireframe</a>
	·
    <a href="https://github.com/jedington/Canvas-Your-Goals/issues">Report Bug(s) // Request Feature(s)</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li><a href="#roadmap">Roadmap</a></li>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
	<li><a href="#summary">➪ Summary :hourglass_flowing_sand:</a></li>
	<li><a href="#to-do-list">➪ To-Do List :memo:</a></li>
	<li><a href="#vision-board">➪ Vision Board :sunrise:</a></li>
	<li><a href="#functions">➪ Functions :cookie:</a></li>
	<li><a href="#accounts">➪ Accounts :closed_lock_with_key:</a></li>
	<li><a href="#compatibility">➪ Compatibility :computer:</a></li>
      </ul>
    </li>
    <li><a href="#documents">➪ Documents 📜</a></li>
    <li><a href="#built-with">➪ Built With 🚧</a></li>
    <li><a href="#references">➪ References :paperclip:</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>

<!-- ROADMAP -->
## Roadmap

Completed:
1. Database (SQL Server). 🗹
2. Migrate Database to Azure. 🗹
3. To-Do List: Goal/Task/Step (MVC). 🗹
4. User (MVC) and Email for Password Reset. 🗹
5. Manage basic authentication / authorization. 🗹
6. Complete project's basic functions to release. 🗹
	
Backlog:
1. Figure out Vision Board (MVC+JS) configuration. ☐
2. Info/Notifications when navigating webpages. ☐
3. Add functions to auto-complete Goals/Tasks. ☐
4. Enable Pagination / allow for many pages. ☐
5. Browser and Device Compatibility where feasible. ☐
	
Optional:
1. Custom front-end design. 🗹
2. Theme colors through JavaScript. 🗹
3. Potentially add in a Calendar (MVC)? ☐
4. Modal page 'popups' through Bootstrap. ☐ 
5. OAuth potentially for easier login / SSO. ☐ 
6. Accelerated Mobile Pages / Mobile App?. ☐
7. Terms & Conditions + Privacy Policy. ☐

*See the [open issues](https://github.com/jedington/Canvas-Your-Goals/issues) for a list of proposed features (and known issues).*


<!-- ABOUT THE PROJECT -->
<details open="open">
  <summary><h2 style="display: inline-block">About The Project</h2>
	
### Summary

We all have goals that are originally ideas we want to accomplish at some point. Most of the time, they are simple tasks in order to get through the day, week, or however long the span is; but sometimes they are not simple, and our goals reach high and far. Sometimes they seem too out of reach to just quantify in order to succeed in them. We come up with dreams that we strive for. Some may use tools like vision boards and create milestones along the way towards their goals. This project is not going to be particularly different or groundbreaking, rather just another rendition of a vision board, reimagined with a to-do list style structure included alongside for each individual goal.</summary>


------
### To-Do List

The first part of the project is a list of tasks that need to be accomplished in order to attain the certain goals. These goals will be on a separate page from the custom page, or vision board. The user should be allowed to create their own separate goals, the tasks under goals, and steps--if necessary--dependent on complexity—in order to achieve said goals. This part of the project should be much simpler than the first to implement from a developer perspective, but this does not mean it will be easy either.

------
### Vision Board

The second--and much more difficult--feature of the project will have a customizable webpage, intended emulate a vision board’s features of something pleasant and inspiring to look at. Many vision board applications have the capability to add images, objects and shapes, as well as text inputs, with the addition of being able to move and adjust the size of them wherever on the page. Like many goals, you have to be realistic, and this part of the project might be too complicated at the moment for me to develop in the next few months. With that in mind, I am fully aware that I may have to settle with some of the vision board features to be simpler than most, or even not released (examples: <a href="#references">References :paperclip:</a>).

------
### Functions

Listing out the types of objects and sections of the website to be CRUD compliant:
1.	Secondary Webpages / To-Do List -- these are being worked on first and will be fairly easy to complete before this year is over.
	  + Simple design, probably like a timeline, and flexible on days, weeks, etc.
	  +	Tasks: list out the details or milestones of certain goals, with each goal having their own tasks to be kept track of & completed. Tasks that have been completed can be crossed-out and changed to green; tasks that are reaching a close deadline to be changed to yellow. Tasks that have been failed to be changed to red, with the option to add more after to make up for the failed task, such as retaking a certification test.
	  +	Steps: to be used if necessary, with the same capabilities as tasks.
2.	Home Webpage / Vision Board -- realistically, this will be accomplished last, since it's the most difficult.
	  +	Editing UI: give capabilities for all the of the below objects.
	  +	Page: adjustable size, background color.
	  +	Title: adjustable size, position, color.
	  +	Additional text: adjustable size, position, color.
	  +	Images: adjustable size, position, opacity, background.
	  +	Objects: lines, shapes, outsourced, etc (uncertain, but will try anyways).

------
### Accounts

The website or application will have register and login capabilities for User accounts. Administrator function will be only for the individual(s) who would manage the background utilities and capabilities of the application itself. In terms of personal information or user privacy, there will not be any financial information or personally identifiable contents, aside from an email address for account recovery purposes. 
 
------
### Compatibility

I consider this to be an important factor, with as much flexibility as possible. Would be ideal to have compatibility across many browsers as well as various types of devices, depending on the operation systems used as well as the size of the native screens the devices may use. And most importantly, usable from the public cloud / internet regardless of what type of browser or device. Additional systems like caching, script minification, CDNs, and other features would be nice for performance/availability, however reach outside the scope or requirements of this current project.

------
## Documents

Diagram of project, table relationships and a very early idea of how the project will flow.
![Project Diagram][project-diagram]
<!-- [![Project Name Screen Shot][project-screenshot]](https://example.com) -->


------
## Built With

[C#](https://docs.microsoft.com/en-us/dotnet/csharp/) • [T-SQL](https://docs.microsoft.com/en-us/sql/t-sql/language-reference?view=sql-server-ver15) • [.NET Core](https://dotnet.microsoft.com/download) • [JavaScript](https://www.javascript.com/) • [CSS](https://www.w3schools.com/css/) • [HTML](https://www.w3schools.com/html/)

------
## References

Some similar tools in existence, much more in-depth or complexity than this project will be.
[Canva](https://www.canva.com/) • [PicMonkey](https://www.picmonkey.com/) • [DreamItAlive](https://www.dreamitalive.com/) • [Corkulous](https://www.corkulous.com/) • [Desygner](https://desygner.com/)
	
------
## Acknowledgements
* [othneildrew](https://github.com/othneildrew/Best-README-Template/) (especially helpful; original creator of this README format)

[GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet) • [Img Shields](https://shields.io) • [Choose an Open Source License](https://choosealicense.com) • [GitHub Pages](https://pages.github.com) • [Animate.css](https://daneden.github.io/animate.css)

[Loaders.css](https://connoratherton.com/loaders) • [Slick Carousel](https://kenwheeler.github.io/slick) • [Smooth Scroll](https://github.com/cferdinandi/smooth-scroll) • [Sticky Kit](http://leafo.net/sticky-kit) • [JVectorMap](http://jvectormap.com) • [Font Awesome](https://fontawesome.com)


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/jedington/Canvas-Your-Goals.svg?style=for-the-badge
[contributors-url]: https://github.com/jedington/Canvas-Your-Goals/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jedington/Canvas-Your-Goals.svg?style=for-the-badge
[forks-url]: https://github.com/jedington/Canvas-Your-Goals/network/members
[stars-shield]: https://img.shields.io/github/stars/jedington/Canvas-Your-Goals.svg?style=for-the-badge
[stars-url]: https://github.com/jedington/Canvas-Your-Goals/stargazers
[issues-shield]: https://img.shields.io/github/issues/jedington/Canvas-Your-Goals.svg?style=for-the-badge
[issues-url]: https://github.com/jedington/Canvas-Your-Goals/issues
[license-shield]: https://img.shields.io/github/license/jedington/Canvas-Your-Goals.svg?style=for-the-badge
[license-url]: https://github.com/jedington/Canvas-Your-Goals/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/julian-edington/
[twitter-shield]: https://img.shields.io/twitter/follow/arcanicvoid?style=for-the-badge&logo=twitter&colorB=555
[twitter-url]: https://twitter.com/arcanicvoid
[project-screenshot]: images/screenshot.png
[project-diagram]: images/Canvas-Your-Goals.svg
