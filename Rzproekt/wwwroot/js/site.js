"use strict";

var appHome = new Vue({
    el: '#appHome',
    data: {
        general: {
            detailse: 'Подробнее'
        },
        header: {
            logo: '~/img/logo.png',
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


        }
    },
    //update: {

    //},
    created() {
        console.log('init');
    },
    methods: {
    }
});
