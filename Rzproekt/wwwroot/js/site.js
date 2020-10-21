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
            '/api/contact/contacts-lead'
        ],
        general: {
            detailse: 'Подробнее'
        },
        header: [],
        service: [],
        about: [],
        cert: [],
        stat: [],
        project: [],
        arrProject: [],
        client: [],
        contact: [],
        contactLead: [],
        footer: []
    },
    created() {
        this.onAllProject();
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
        toggleChat() {
            var element = document.getElementsByClassName("main-block-chat");
            element[0].classList.toggle("main-block-chat-hide")
        }
    }
});
window.addEventListener('wheel', event => {
    appHome.getBlocksSevices();
});
