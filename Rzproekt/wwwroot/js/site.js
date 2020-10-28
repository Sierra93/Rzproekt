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
        countIdCert: 1,
        urlApi: 'https://localhost:44349',
        //urlApi: 'https://devmyprojects24.xyz',
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
        dialogActiveId: ''
    },
    created() {
        //this.getUserId();
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
                self.getBlocksSevices();
            }
            setTimeout(Carusel, 100);
            this.onAllProject();
            this.checedUserId();
            appHome.$data.blocksServices = document.getElementsByClassName("serviceTxt");
            appHome.$data.aboutTxtTextarea = document.getElementsByClassName("aboutTxtTextarea");
            appHome.$data.aboutDetailTxtTextarea = document.getElementsByClassName("aboutDetailTxtTextarea");
        })
    },
    methods: {
        getBlocksSevices() {
            autosize(this.blocksServices);
            autosize(this.aboutTxtTextarea);
            autosize(this.aboutDetailTxtTextarea);
            $(".fancybox").fancybox({
                selector: '.imglist a:visible',
                buttons: [
                    'slideShow',
                    'zoom',
                    'thumbs',
                    'close'
                ]
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
                        console.log('_getData', response.data);
                        switch (response.data[0].block) {
                            case 'header':
                                let arrId = ['','#main', '#service', '#about', '#project', '#client', '#contact'];
                                self.$data.header = response.data;
                                self.$data.smoothScrollArr = arrId;
                                console.log('header получен', response.data);
                                break;
                            case 'service':
                                self.$data.service = response.data;
                                console.log('service получен', response.data);
                                break;
                            case 'about':
                                self.$data.about = response.data;
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
            if ( countCert < 0) {
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
        toggleChat() {
            var element = document.getElementsByClassName("main-block-chat");
            element[0].classList.toggle("main-block-chat-hide")
        },
        checedUserId() {
            let userId = sessvars.userId;
            if (userId) {
                this.getMsgList(userId); 
            } else {
                this.getUserId();
            }
            
        },
        checedSendMsg() {
            let userId = sessvars.userId;
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
                                    self.$data.arrMsgChat = response.data.aMessages;
                                    self.$data.dialogActiveId = response.data.aDialogs.dialogId;
                                    document.getElementById('msgChat').value = '';
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
                            self.$data.arrMsgChat = response.data.aMessages;
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
            var result = '';
            let position = '';
            var words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM';
            var max_position = words.length - 1;
            for (let i = 0; i < 50; ++i) {
                position = Math.floor(Math.random() * max_position);
                result = result + words.substring(position, position + 1);
            }
            sessvars.userId = result;
            this.getMsgList(result);
        }
    }
});

window.addEventListener('wheel', event => {
    appHome.getBlocksSevices();
});

