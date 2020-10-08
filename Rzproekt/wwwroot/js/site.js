﻿"use strict";

//window.addEventListener("hashchange", function (e) {
//    //document.getElementById('o').innerHTML = e.oldURL;
//    //document.getElementById('n').innerHTML = e.newURL;
//	console.log("test");
//}, false);

//$(window).bind('hashchange', function () {
//    console.log("test");
//});

//if (location.href.includes("#") || location.href.includes("/")) {
//    console.log("test");
//}

//if ("onhashchange" in window) {
//    alert("The browser supports the hashchange event!");
//}

var appHome = new Vue({
    el: '#appHome',
    data: {
        date: new Date().getFullYear(),
        general: {
            detailse: 'Подробнее'
        },
        header: {
            logo: '',
            nav: {
                main: 'Главная',
                service: 'Услуги',
                project: 'Проекты',
                about: 'О нас',
                contacts: 'Контакты'
            }
        },
        block: {
            title: {
                mainTitle: 'ЛИДЕРЫ В ОБЛАСТИ ПРОЕКТИРОВАНИЯ',
                service: 'УСЛУГИ',
                about: 'О НАС',
                project: 'ПРОЕКТЫ',
                clients: 'КЛИЕНТЫ',
                contacts: 'КОНТАКТЫ',
            }
        },
        service: {
            title1: 'УСЛУГА 1',
            title2: 'УСЛУГА 2',
            title3: 'УСЛУГА 3',
            txt1: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',
            txt2: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum',
            txt3: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum'
        },
        about: {
            aboutTxt: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum'
        },
        counter: {
            ageCompany: {
                counter: 80,
                txt: 'ЛЕТ НА РЫНКЕ'
            },
            projects: {
                counter: '>50',
                txt: 'СТРОИТЕЛЬНЫХ ОБЪЕКТОВ'
            },
            sertificats: {
                counter: 25,
                txt: 'ЛИЦЕНЦИЙ И СЕРТИФИКАТОВ'
            },
            directActivity: {
                counter: 16,
                txt: 'НАПРАВЛЕНИЙ ДЕЯТЕЛЬНОСТИ'
            }
        },
        project: {
            vimpel: 'ЦОД ОАО "Вымпелком" г.Ярославль',
            citroen: 'Автосалон "CITROEN"',
            archive: 'Централизованное архивохранилище ЦФО, г. Калуга',
            tireFactory: 'Воронежский шинный завод'
        },
        contacts: {
            title: {
                office: 'Центральный офис'
            },
            infoCompany: {
                address: 'Адрес: Россия, 150003, г.Ярославль, ул.Советская, 69',
                mail: 'E-mail: mail@rzproekt.ru',
                number: 'Тел./факс: (4852) 25-18-35, 25-24-74'
            }
        }
    },
    //update: {

    //},
    created() {
        console.log('init');
        this._getLogo();
    },
    methods: {
        // Функция получает лого.
        _getLogo() {
            let sUrl = 'https://localhost:44349/api/header/get-header';
            
            try {
                axios.post(sUrl)
                    .then((response) => {
                        console.log('Лого получен', response.data);
                        this.header.logo = response.data[0].url;
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest.response.data);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        smoothScroll() {
            $('.custom-navbar a, #home a').on('click', function (event) {
                var $anchor = $(this);
                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top - 49
                }, 1000);
                event.preventDefault();
            });
        }  
    }
});
