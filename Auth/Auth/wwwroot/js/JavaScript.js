const links = document.querySelectorAll(".app__buttons__item");


links.forEach((link) => {

	link.addEventListener("click", (e) => {

		e.preventDefault();

		changeClassOff(links);

		link.classList.add("active");

		if (link.dataset.type == "tur") {
			setTimeout(redirect, 500, "/Home/InTur");
		} else if (link.dataset.type == "agent") {
			setTimeout(redirect, 500, "/Home/InAgent");
		} else if (link.dataset.type == "regagent") {
			setTimeout(redirect, 500, "/Home/RegAgent");
		} else if (link.dataset.type == "regtur") {
			setTimeout(redirect, 500, "/Home/RegTur");
        }



	});

});

function redirect(href) {
	window.location.replace(href);
}

function changeClassOff(objArr) {
	objArr.forEach((obj) => {
		obj.classList.remove("active");
	});
}