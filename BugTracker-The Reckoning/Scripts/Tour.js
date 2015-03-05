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
	    buttons: { Next: 1 },
	    focus: 0,
	    position: { container: '', x: 0, y: 120, width: 275 },
	    submit: tourSubmitFunc
	},
	{
	    title: 'Registration',
	    html: 'Security is important. BugTracker requires users to register on the site.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#loginRegister', x: -325, y: 80, width: 400, arrow: 'tr' },
	    submit: tourSubmitFunc
	},
    {
        title: 'Login',
        html: 'Returning users may log-in and log-off here.',
        buttons: { Prev: -1, Next: 1},
        focus: 0,
        position: { container: '#login', x: -325, y: 80, width: 400, arrow: 'tr' },
        submit: tourSubmitFunc
    },
    {
        title: "Roles",
        html: 'Authorization is Role-based using Entity Framework. After registering, a user is assigned the Submitter Role.  A submitter is only allowed to create and view their own tickets.',
        buttons: { Prev: -1, Next: 1 },
        focus: 0,
        position: { container: '#Users', x: 0, y: 80, width: 200},
        submit: tourSubmitFunc
    },
	{
	    title: "Projects",
        html: 'Administrators or Project Managers may add projects.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#Projects', x: 0, y: 0, width: 200, arrow: 'tl' },
	    submit: tourSubmitFunc
	},
	{
	    title: 'Tickets',
	    html: 'Submitters create Tickets under Projects.  These Tickets may contain Attachments and/or Comments.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#Tickets', x: -10, y: -5, width: 200, arrow: 'bl' },
	    submit: tourSubmitFunc
	},
	{
	    title: 'About BugTracker',
        html: 'BugTracker, is a collaborative effort for Coder Foundry.',
	    buttons: { Prev: -1, Next: 1 },
	    focus: 0,
	    position: { container: '#About', x: -10, y: -5, width: 200, arrow: 'bl' },
	    submit: tourSubmitFunc
	},
	{
	    title: 'Contact BugTracker',
	    html: 'Contact us to purchase BT, or for additional information.',
	    buttons: { Done: 2 },
	    focus: 0,
	    position: { container: '#Contact', x: 370, y: 120, width: 275, arrow: 'lt' },
	    submit: tourSubmitFunc
	}
];
$.prompt(tourStates);