"use strict";



var appHome = new Vue({
    el: '#appHome',
    data: {
        date: new Date().getFullYear(),
        blocksServices: '',
        aboutTxtTextarea: '',
        aboutDetailTxtTextarea: '',
        ageCompanyTxt: '',
        smoothScrollArr: [],
        collectionimgProject: [],
        countIdCert: 1,
        countIdPrjImg: 0,
        animStat: true,
        urlApi: 'https://localhost:44349',
        //urlApi: 'https://rzproekt.ru',
        urlAboutMain: '',
        listRequests: [
            '/api/header/get-header',
            '/api/order/get-orders',
            '/api/about/get-about',
            '/api/statistic/get-statistic',
            '/api/project/get-projects',
            '/api/client/get-clients',
            '/api/contact/contacts-company',
            '/api/footer/get-footer',
            '/api/back-office/get-certs',
            '/api/back-office/get-awards',
            '/api/contact/contacts-lead'
        ],
        header: [],
        service: [],
        about: [],
        cert: [],
        awards: [],
        stat: [],
        project: [],
        arrProject: [],
        client: [],
        contact: [],
        contactLead: [],
        footer: [],
        arrMsgChat: [],
        ArrImgDetAbout: [],
        dialogActiveId: '',
        userId: ""
    },
    created() {
    },

    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        this.$nextTick(function () {
            let self = this;
            let ageCompanyTxt = +JSON.stringify(this.$data.date - 1938).slice('1');
            this.$data.ageCompanyTxt = this.declination(ageCompanyTxt, 'ГОД', 'ГОДА', 'ЛЕТ') + " НА РЫНКЕ";
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            });
            function Carusel() {
                self.certCarusel(true);
                self.getArrImgDetAbout();
                self.getBlocksSevices();
            }
            setTimeout(Carusel, 300);

            this.onAllProject();
            this.checedUserId();
            appHome.$data.blocksServices = document.getElementsByClassName("serviceTxt");
            appHome.$data.aboutTxtTextarea = document.getElementsByClassName("aboutTxtTextarea");
            appHome.$data.aboutDetailTxtTextarea = document.getElementsByClassName("aboutDetailTxtTextarea");
            function getMsg() {
                let cookie = document.cookie.split(';');
                cookie = cookie[cookie.length - 1].substr(1);
                appHome.$data.userId = cookie;
                self.getMsgList(cookie);
            }
            setInterval(getMsg, 1000);

        })
    },
    methods: {
        getBlocksSevices() {
            autosize(this.blocksServices);
            autosize(this.aboutTxtTextarea);
            autosize(this.aboutDetailTxtTextarea);
            this.returnMain();
            this.animateCount();
            $(".about-right").css('background-image', "url(" + this.urlAboutMain + ")");
            $(".fancybox").fancybox({
                selector: '.imglist a:visible',
                buttons: [
                    'slideShow',
                    'zoom',
                    'close'
                ]
            });
            $("[data-fancybox='fancyboxProject1']").fancybox({
                selector: '.imglist a:visible',
                buttons: [
                    'slideShow',
                    'zoom',
                    'close'
                ]
            });
            $("[data-fancybox='fancyboxProject2']").fancybox({
                selector: '.imglist a:visible',
                buttons: [
                    'slideShow',
                    'zoom',
                    'close'
                ]
            });
            $("[data-fancybox='fancyboxProject3']").fancybox({
                selector: '.imglist a:visible',
                buttons: [
                    'slideShow',
                    'zoom',
                    'close'
                ]
            });
            $('.about-wrapper-img').slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                arrows: false,
                autoplay: true,
                autoplaySpeed: 2000,
            });
            $('.multiple-items').slick({
                dots: true,
                infinite: false,
                speed: 300,
                slidesToShow: 5,
                slidesToScroll: 4,
                responsive: [
                    {
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3,
                            infinite: true,
                            dots: true
                        }
                    },
                    {
                        breakpoint: 800,
                        settings: {
                            slidesToShow: 2,
                            slidesToScroll: 2
                        }
                    },
                    {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1
                        }
                    }
                ]
            });

        },
        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;

            try {
                axios.post(sUrl)
                    .then((response) => {
                        if (response.data.length == 0) {
                            response.data = [{
                                mainTitle: '',
                                block: 'project'
                            }];
                        }
                        switch (response.data[0].block) {
                            case 'header':
                                self.$data.header = response.data;
                                console.log('header получен', response.data);
                                break;
                            case 'service':
                                self.$data.service = response.data;
                                console.log('service получен', response.data);
                                break;
                            case 'about':
                                self.$data.about = response.data;
                                self.$data.urlAboutMain = response.data[0].url;
                                console.log('about получен', response.data);
                                break;
                            case 'cert':
                                self.$data.cert = response.data;
                                console.log('cert получены', response.data);
                                break
                            case 'award':
                                self.$data.awards = response.data;
                                console.log('awards получены', response.data);
                                break
                            case 'stat':
                                self.$data.stat = response.data;
                                console.log('stat получен', response.data);
                                break;
                            case 'project':
                                self.$data.project = response.data;
                                console.log('project получен', response.data);
                                break;
                            case 'client':
                                self.$data.client = response.data;
                                console.log('client получен', response.data);
                                break;
                            case 'contact':
                                self.$data.contact = response.data;
                                console.log('contact получен', response.data);
                                break;
                            case 'contact_lead':
                                self.$data.contactLead = response.data;
                                console.log('contactLead получен', response.data);
                                break;
                            case 'footer':
                                self.$data.footer = response.data;
                                console.log('footer получен', response.data);
                                break;
                        }

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        getArrImgDetAbout() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/about/about-details';

            axios.post(sUrl)
                .then((response) => {
                    self.$data.ArrImgDetAbout = response.data;
                    console.log("success / getArrImgDetAbout", response);
                    //var pc = document.getElementById("pic_cntr");
                    
                    //for (let i of response.data) {
                    //    var pic = document.createElement("IMG");
                    //    pic.src = i;
                    //    pc.appendChild(pic);
                    //}
                    self.createSliderAbout(response.data);
                    
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        createSliderAbout(data) {
            var countImg = data.length - 1;
            var pc = document.getElementById("pic_cntr");
            var pic = document.createElement("IMG");
            pic.src = data[countImg];
            pc.appendChild(pic);
            
            function Carusel() {
                if (countImg <= data.length - 1) {
                    if (data[countImg - 1]) {
                        pic.src = data[countImg - 1];
                        pc.appendChild(pic);
                        countImg++;
                    } else {
                        pic.src = data[2];
                        pc.appendChild(pic);
                        countImg++;
                    }
                } else {
                    countImg = 0;
                }
            }
            setInterval(Carusel, 3000);
        },
        onAllProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/project/all-projects';

            axios.post(sUrl)
                .then((response) => {
                    if (!response.data) { self.$data.AllProject = []; return }
                    self.$data.arrProject = response.data;
                    console.log("success / getAllProject", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        smoothScroll(event) {
            var $anchor = event.target;
            $('html, body').stop().animate({
                scrollTop: $($anchor.getAttribute('href')).offset().top - 100
            }, 1000);
            event.preventDefault();
            this.getBlocksSevices(); //запускает автосайз
        },
        declination(number, one, two, five) {
            let n = Math.abs(number);
            n %= 100;
            if (n >= 5 && n <= 20) {
                return five;
            }
            n %= 10;
            if (n === 1) {
                return one;
            }
            if (n >= 2 && n <= 4) {
                return two;
            }
            return five;
        },
        certCarusel(e) {
            let listCert = document.getElementsByClassName('cert-item');
            if (!listCert) return;
            if (e.target) var direction = e.target.parentNode.getAttribute('customId')
            if (direction) {
                this.countIdCert++;
            } else {
                this.countIdCert--;
            }
            let countCert = this.countIdCert;
            if (countCert < 0) {
                this.countIdCert = listCert.length - 1;
                countCert = listCert.length - 1;
            } else if (countCert > listCert.length - 1) {
                this.countIdCert = 0;
                countCert = 0;
            }
            let countL = countCert - 1;
            if (countL < 0) countL = listCert.length - 1;
            let countR = countCert + 1;
            if (!listCert[countR]) countR = 0;
            if (!listCert[countL]) countL = 0;

            for (let i = 0; i < listCert.length; i++) {

                if (countL == i) {
                    listCert[i].classList.remove("item-cert-hidden");
                    listCert[i].classList.remove("item-cert-center");
                    listCert[i].classList.remove("item-cert-right");
                    listCert[i].classList.add("item-cert-left");
                } else if (countCert == i) {
                    listCert[i].classList.remove("item-cert-hidden");
                    listCert[i].classList.remove("item-cert-left");
                    listCert[i].classList.remove("item-cert-right");
                    listCert[i].classList.add("item-cert-center");
                } else if (countR == i) {
                    listCert[i].classList.remove("item-cert-hidden");
                    listCert[i].classList.remove("item-cert-left");
                    listCert[i].classList.remove("item-cert-center");
                    listCert[i].classList.add("item-cert-right");
                } else {
                    listCert[i].classList.remove("item-cert-left");
                    listCert[i].classList.remove("item-cert-center");
                    listCert[i].classList.remove("item-cert-right");
                    listCert[i].classList.add("item-cert-hidden");
                }

            }

        },
        awardsCarusel(e) {
            let listAwards = document.getElementsByClassName('awards-item');
            if (!listAwards) return;
            if (e.target) var direction = e.target.parentNode.getAttribute('customId')
            if (direction) {
                this.countIdCert++;
            } else {
                this.countIdCert--;
            }
            let countCert = this.countIdCert;
            if (countCert < 0) {
                this.countIdCert = listAwards.length - 1;
                countCert = listAwards.length - 1;
            } else if (countCert > listAwards.length - 1) {
                this.countIdCert = 0;
                countCert = 0;
            }
            let countL = countCert - 1;
            if (countL < 0) countL = listAwards.length - 1;
            let countR = countCert + 1;
            if (!listAwards[countR]) countR = 0;
            if (!listAwards[countL]) countL = 0;

            for (let i = 0; i < listAwards.length; i++) {

                if (countL == i) {
                    listAwards[i].classList.remove("item-cert-hidden");
                    listAwards[i].classList.remove("item-cert-center");
                    listAwards[i].classList.remove("item-cert-right");
                    listAwards[i].classList.add("item-cert-left");
                } else if (countCert == i) {
                    listAwards[i].classList.remove("item-cert-hidden");
                    listAwards[i].classList.remove("item-cert-left");
                    listAwards[i].classList.remove("item-cert-right");
                    listAwards[i].classList.add("item-cert-center");
                } else if (countR == i) {
                    listAwards[i].classList.remove("item-cert-hidden");
                    listAwards[i].classList.remove("item-cert-left");
                    listAwards[i].classList.remove("item-cert-center");
                    listAwards[i].classList.add("item-cert-right");
                } else {
                    listAwards[i].classList.remove("item-cert-left");
                    listAwards[i].classList.remove("item-cert-center");
                    listAwards[i].classList.remove("item-cert-right");
                    listAwards[i].classList.add("item-cert-hidden");
                }

            }
        },
        projectCarusel(e) {
            let listProject = this.$data.arrProject[0].url;
            let directionPrev = e.target.getAttribute('customId');
            if (directionPrev == 'true') {
                this.$data.arrProject[0].url = listProject[1];
            }
        },
        toggleChat() {
            var element = document.getElementsByClassName("main-block-chat");
            element[0].classList.toggle("main-block-chat-hide")
        },
        checedUserId() {
            let cookie = document.cookie.split(';');
            cookie = cookie[cookie.length - 1].substr(1);
            if (cookie) {
                this.getMsgList(cookie);
            } else {
                this.getUserId();
            }

        },
        checedSendMsg() {
            let userId = appHome.$data.userId;
            this.setUserId(userId);
        },
        setUserId(UserCode) {
            let self = this;
            let MessageText = document.getElementById('msgChat').value;
            let DialogId = self.$data.dialogActiveId;
            let sUrl = appHome.$data.urlApi + "/api/message/send";
            let IsAdmin = 'false';

            let oData = {
                UserCode,
                MessageText,
                IsAdmin,
                DialogId
            }
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        console.log("ok");
                        if (response.data.aMessages) {
                            response.data.aMessages.forEach(function (el) {
                                el.created = self.formatDateTime(el.created);
                            });
                            self.$data.arrMsgChat = response.data.aMessages;
                            self.$data.dialogActiveId = response.data.aDialogs.dialogId;
                            document.getElementById('msgChat').value = '';
                            document.getElementById('helloMsg').style.display = 'none';
                        }

                    })
                    .catch((XMLHttpRequest) => {
                        console.log("error");
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        getMsgList(UserId) {
            let self = this;
            let sUrl = appHome.$data.urlApi + "/api/message/user-messages";

            let oData = {
                UserId
            }
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        console.log("ok");
                        if (response.data.aMessages) {
                            response.data.aMessages.forEach(function (el) {
                                el.created = self.formatDateTime(el.created);
                            });
                            self.$data.arrMsgChat = response.data.aMessages;
                        }
                        if (!!self.$data.arrMsgChat.length) {
                            document.getElementById('helloMsg').style.display = 'none';
                        } else {
                            document.getElementById('helloMsg').style.display = 'block';
                        }

                    })
                    .catch((XMLHttpRequest) => {
                        console.log("error");
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        getUserId() {
            let result = '';
            let position = '';
            let words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM';
            let max_position = words.length - 1;

            for (let i = 0; i < 50; ++i) {
                position = Math.floor(Math.random() * max_position);
                result = result + words.substring(position, position + 1);
            }
            document.cookie = result;
            let cookie = document.cookie.split(';');
            cookie = cookie[cookie.length - 1].substr(1);
            appHome.$data.userId = cookie;
            this.getMsgList(cookie);
        },
        onGetAllImgProject(e) {
            let self = this;
            let sUrl = appHome.$data.urlApi + "/api/project/collection";
            let ProjectId = e;
            
            try {
                axios.get(sUrl + '/' + ProjectId)
                    .then((response) => {
                        console.log("ok");
                        self.$data.collectionimgProject = response.data;
                        self.uniteDatePrj(e);
                    })
                    .catch((XMLHttpRequest) => {
                        console.log(XMLHttpRequest, "error");
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        uniteDatePrj(e) {
            let self = this;
            let idPrj, collPrj, collImgPrj, nav, count = self.$data.countIdPrjImg;
            collImgPrj = self.$data.collectionimgProject;
            collPrj = self.$data.project;
            let thisPage = document.URL.split('/')[3];

            if (thisPage === "project-details") {
                collPrj = self.$data.arrProject;
            }

            if (!!e.currentTarget) {
                idPrj = +e.currentTarget.getAttribute('projectId');
                nav = e.currentTarget.getAttribute('nav');
            } else {
                idPrj = e;
                nav = "next"
            }

            if (!collImgPrj.length) {
                self.onGetAllImgProject(idPrj);
                return;
            } else if (!(collImgPrj[0].projectId == idPrj)) {
                self.onGetAllImgProject(idPrj);
                return;
            }

            for (let i of collPrj) {
                if (i.projectId == idPrj) {

                    if (nav === 'next') {
                        count++;
                        if (count >= collImgPrj.length) {
                            count = 0;
                        }
                        self.$data.countIdPrjImg = count;
                    } else {
                        count--;
                        if (count < 0) {
                            count = collImgPrj.length - 1;
                        }
                        self.$data.countIdPrjImg = count;
                    }
                    i.url = collImgPrj[count].url;
                }
            }


         },
        returnMain() {
            let target = document.referrer.split('/')[3];
            switch (target) {
                case 'project-details':
                    window.location.hash = "project"
                    break;
                case 'about-details':
                    window.location.hash = "about"
                    break;
            }
        },
        formatDateTime(par) {
            let parDate = par.split('T')[0];
            let parTime = par.split('T')[1];
            parTime = parTime.split('.')[0];
            parDate = parDate.split('-').reverse().join('-');
            return parDate + ' ' + parTime;
        },
        animateCount() {
            let countbox = ".benefits__inner";
            $(window).on("scroll load resize", function () {
                //if (!show) return false; // Отменяем показ анимации, если она уже была выполнена
                let w_top = $(window).scrollTop(); // Количество пикселей на которое была прокручена страница
                let e_top = $(countbox).offset().top; // Расстояние от блока со счетчиками до верха всего документа
                let w_height = $(window).height(); // Высота окна браузера
                let d_height = $(document).height(); // Высота всего документа
                let e_height = $(countbox).outerHeight(); // Полная высота блока со счетчиками
                if (w_top + 500 >= e_top || w_height + w_top == d_height || e_height + e_top < w_height) {
                    if (appHome.$data.animStat) {
                        appHome.$data.animStat = false;
                        var numberStartTwo = 0;
                        var numberStart = 470;
                        var numberStartThree = 6920;
                        var numberFinishOne = appHome.$data.stat[0].number;
                        var numberFinishTwo = appHome.$data.stat[1].number;
                        var numberFinishThree = appHome.$data.stat[2].number;
                        setInterval(function () {
                            ++numberStart;
                            if (numberStart <= numberFinishOne) {
                                $('.numbersOne').text(numberStart);
                            } else { $('.numbersOne').text(numberFinishOne); };
                        }, 20);
                        setInterval(function () {
                            ++numberStartTwo;
                            if (numberStartTwo <= numberFinishTwo) {
                                $('.numbersTwo').text(numberStartTwo);
                            } else { $('.numbersTwo').text(numberFinishTwo); };
                        }, 20);
                        setInterval(function () {
                            ++numberStartThree;
                            if (numberStartThree <= numberFinishThree) {
                                $('.numbersThree').text(numberStartThree);
                            } else { $('.numbersThree').text(numberFinishThree); };
                        }, 20);
                    }
                }
            });
        }
    }
});

window.addEventListener('wheel', event => {
    appHome.getBlocksSevices();
});