"use strict";

//const hubConnection = new signalR.HubConnectionBuilder()
//	.withUrl("/chat")
//	.build();

//hubConnection.on("Send", function (data) {
//	let elem = document.createElement("p");
//	elem.appendChild(document.createTextNode(data));
//	let firstElem = document.getElementById("chatroom").firstChild;
//	document.getElementById("chatroom").insertBefore(elem, firstElem);

//});

//document.getElementById("sendBtn").addEventListener("click", function (e) {
//	let message = document.getElementById("message").value;
//	hubConnection.invoke("Send", message);
//});

//hubConnection.start();

var back_office = new Vue({
    el: "#back_office",
    data() {
        return {
            files: '',
            filesService: '',
            filesAbout: '',
            filesCert: '',
            date: new Date().getFullYear(),
            urlApi: 'https://localhost:44349',
            //urlApi: 'https://devmyprojects24.xyz',
            listRequests: [
                '/api/header/get-header',
                '/api/order/get-orders',
                '/api/about/get-about',
                '/api/statistic/get-statistic',
                '/api/project/get-projects',
                '/api/client/get-clients',
                '/api/contact/get-contacts',
                '/api/footer/get-footer',
                '/api/back-office/get-certs'
            ],
            general: {
                detailse: 'Подробнее'
            },
            header: [],
            service: [],
            about: [],
            cert: [],
            arrCertSearth: [],
            stat: [],
            project: [],
            client: [],
            contact: [],
            footer: []
        }
    },
    update: {

    },
    created() {
        console.log('init');

    },
    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        this.$nextTick(function () {
            let self = this;
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            })

        })
    },
    methods: {
        // Функция собирает файлы header.
        handleFilesUpload() {
            let filesLogo = document.getElementById('filesLogo').files[0];
            let filesVideoBgHeader = document.getElementById('filesVideoBgHeader').files[0];

            if (!!filesLogo) {
                this.files = filesLogo;
            } else if (!!filesVideoBgHeader) {
                this.files = filesVideoBgHeader;
            }
        },
        handleFilesUploadService() {
            let arrBlocksImg = document.getElementsByClassName('form-files-service');
            this.filesService = arrBlocksImg;
        },
        handleFilesUploadAbout() {
            let arrBlocksImg = document.getElementsByClassName('form-files-about');
            this.filesAbout = arrBlocksImg;
        },
        handleFilesUploadClient() {
            let arrBlocksImg = document.getElementsByClassName('form-files-client');
            this.filesService = arrBlocksImg;
        },
        handleFilesUploadDetAbout() {
            let filesAbout = document.getElementsByClassName('form-files-about')[0].files[0];
            let filesDetAbout = document.getElementsByClassName('form-files-det-about')[0].files[0];

            if (!!filesAbout) {
                this.filesAbout = filesAbout;
            } else if (!!filesDetAbout) {
                this.filesAbout = filesDetAbout;
            }
        },
        handleFilesUploadCert() {
            let filesCert = document.getElementsByClassName('form-files-cert')[0].files;
            this.filesCert = filesCert;
        },

        // Отправляет измененные данные первого блока сайта
        onChangeHeader() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-header';
            let MainItem = $('.header-menu-txt');
            let MainNum = $('.header-menu-num')[0].value;
            let formData = new FormData();

            //formData = formData.get('filesLogo');
            let mainItemArr = [];
            for (let item of MainItem) {
                mainItemArr.push(item.value)
            }

            let MainTitle = $('.header-menu-title')[0].value;

            let oData = {
                MainItem: mainItemArr,
                MainTitle,
                MainNum
            };

            formData.set('filesLogo', this.files);
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока Услуги
        onChangeService(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-order';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let OrderId = idService + 1;
            let MainTitle = $('.service-main-title')[0].value;
            let Title = $('.service-title')[OrderId-1].value;
            let Text = $('.service-text')[OrderId-1].value;
            
            
            let formData = new FormData();
            let oData = {
                OrderId,
                MainTitle,
                Title,
                Text
            };
            if (!!this.filesService[idService]) {
                formData.set('filesLogo', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
    
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока About
        onChangeAbout(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-about';
            let MainTitle = $('.about-Maintitle')[0].value;
            let Text = $('.about-text')[0].value;
            let detMainTitle = $('.about-Det-Maintitle')[0].value;
            let detTitle = $('.about-DetTitle')[0].value;
            let detText = $('.about-detail-text')[0].value;
            let mainImg = !!e.target.getAttribute('id');
            let idService = +e.target.getAttribute('idCustom') - 1;
            let Id = idService + 1;
            let formData = new FormData();
            let oData = {
                Id,
                MainTitle,
                Text,
                detMainTitle,
                detTitle,
                detText,
                mainImg
            };
            if (!!this.filesService[idService]) {
                formData.set('filesAbout', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            //mainTitle, title, text, url, buttonText, dopMainTitle, dopMainTitle, dopTitle, dopText, dopUrl, certUrl

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onSearthCert() {
            let self = this;
            let CertName = document.getElementById("searchCert").value;
            let sUrl = self.$data.urlApi + '/api/back-office/get-certs';
            let oData = {
                CertName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    self.$data.arrCertSearth = response.data;
                    console.log("success / getCert", response);
                })
                .catch((XMLHttpRequest) => {
                    console.log("request send error", XMLHttpRequest);
                });
        },
        onDelCert() {

        },
        onAddCert() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-cert';
            let nameCert = document.getElementById("nameCert").value;
            let formData = new FormData();
            let oData = {
                nameCert
            }
            if (!!this.filesCert) {
                formData.set('filesCert', this.filesCert[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        onChangeStat() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-stat';
            let nOne = $('.stat-menu-number-one')[0].value;
            let sOne = $('.stat-menu-txt-one')[0].value;
            let nTwo = $('.stat-menu-number-Two')[0].value;
            let sTwo = $('.stat-menu-txt-Two')[0].value;
            let nThree = $('.stat-menu-number-three')[0].value;
            let sThree = $('.stat-menu-txt-three')[0].value;

            let oData = {
                nOne,
                sOne,
                nTwo,
                sTwo,
                nThree,
                sThree
            }
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onChangeClient(e) {
            // Отправляет измененные данные блока Client
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-client';
            let MainTitle = $('.client-menu-title')[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;
            let formData = new FormData();
            let oData = {
                ClientId,
                MainTitle
            };
            if (!!this.filesService[idService]) {
                formData.set('filesClient', this.filesService[idService].files[0]);
            }
            
            formData.set('jsonString', JSON.stringify(oData));


            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onAddClient(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-client';
            let formData = new FormData();
            let idService = +e.target.getAttribute('idCustom') - 1;
            formData.set('filesClient', this.filesService[idService - 1].files[0]);

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onDelClient(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/delete-client';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;
            let oData = {
                ClientId
            };
            try {
                axios.put(sUrl, oData)
                    .then((response) => {
                        console.log('Данные успешно удалены');

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;


            try {
                axios.post(sUrl)
                    .then((response) => {
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
                                console.log('about получен', response.data);
                                break;
                            case 'cert':
                                self.$data.cert = response.data;
                                console.log('cert получен', response.data);
                                break;
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
        onSignIn() {
            let self = this;
            let Login = document.getElementById('login').value;
            let Password = document.getElementById('password').value;
            let sUrl = self.$data.urlApi + '/api/auth/signin';
            let oData = {
                Login,
                Password
            };
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        if (response.data.access_token) window.location.href = self.$data.urlApi + '/back-office';

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        }
    }
});