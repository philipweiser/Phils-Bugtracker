var tourSubmitFunc = function (e, v, m, f) {
    if (v === -1) {
        $.prompt.prevState();
        return false;
    }
    else if (v === 1) {
        $.prompt.nextState();
        return false;
    }
},
tourStates = [
	{
	    title: 'Welcome to BugTracker',
	    html: 'Are you ready to begin the tour?',
	    buttons: { Yes: 1 },
	    focus: 0,
	    position: { container: '', x: 0, y: 120, width: 275 },
	    submit: tourSubmitFunc
	},
	{
	    title: 'Registration',
	    html: 'Security is important. BugTracker requires users to register on the site before creating tickets.<br><br> For demo purposes, you have been automatically logged in as an Administrator.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#loginRegister', x: -325, y: 80, width: 400, arrow: 'tr' },
	    submit: tourSubmitFunc
	},
    {
        title: 'Login',
        html: 'Returning users may log-in and log-off here.',
        buttons: { Prev: -1, Next: 1 },
        focus: 0,
        position: { container: '#login', x: -325, y: 80, width: 400, arrow: 'tr' },
        submit: tourSubmitFunc
    },
    {
        title: "Roles",
        html: 'Authorization is Role-based using Entity Framework. After registering, a user is assigned the Submitter Role.  A submitter is only allowed to create and view their own tickets.',
        buttons: { Prev: -1, Next: 1 },
        focus: 0,
        position: { container: '#Users', x: 0, y: 80, width: 400 },
        submit: tourSubmitFunc
    },
    {
        title: "User Management",
        html: 'Project Managers and Administrators can assign Tickets, Roles and Projects through the Users Menu.',
        buttons: { Prev: -1, Next: 1 },
        focus: 0,
        position: { container: '#Users', x: 0, y: 80, width: 400, arrow: 'tl'},
        submit: tourSubmitFunc
    },
    	{
    	    title: 'Tickets',
    	    html: 'Users can create and view their tickets here.  These Tickets may contain Attachments and/or Comments. Ticket Types, Priorities and Statuses can be defined using the dropdown.',
    	    buttons: { Prev: -1, Next: 1 },
    	    focus: 0,
    	    position: { container: '#Tickets', x: 10, y: 80, width: 400, arrow: 'tl' },
    	    submit: tourSubmitFunc
    	},
	{
	    title: "Projects",
	    html: 'Administrators and Project Managers may create new projects.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#Projects', x: 0, y: 80, width: 400, arrow: 'tl' },
	    submit: tourSubmitFunc
	},
	{
	    title: 'Contact BugTracker',
	    html: 'The Contact page shows multiple contact methods to communicate with the application\'s author.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#Contact', x: 10, y: 80, width: 400, arrow: 'tl' },
	    submit: tourSubmitFunc
	},
{
    title: 'About BugTracker',
    html: 'BugTracker was created by Philip Weiser.  Read about the various technologies used in this application here.',
buttons: { Thanks : 2 },
focus: 0,
    position: { container: '#About', x: 10, y: 80, width: 400, arrow: 'tl' },
submit: tourSubmitFunc
}
];
$.prompt(tourStates);