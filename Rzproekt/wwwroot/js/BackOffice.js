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
            date: new Date().getFullYear(),
            urlApi: 'https://localhost:44349',
            listRequests: [
                '/api/header/get-header',
                '/api/order/get-orders',
                '/api/about/get-about',
                '/api/statistic/get-statistic',
                '/api/project/get-projects',
                '/api/client/get-clients',
                '/api/contact/get-contacts',
                '/api/footer/get-footer'
            ],
            general: {
                detailse: 'Подробнее'
            },
            header: [],
            service: [],
            about: [],
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
            let MainTitle = $('.service-main-title')[0].value;
            let Title = $('.service-title')[0].value;
            let Text = $('.service-text')[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let OrderId = idService + 1;
            let formData = new FormData();
            let oData = {
                OrderId,
                MainTitle,
                Title,
                Text
            };
            formData.set('filesLogo', this.filesService[idService].files[0]);
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
            let sUrl = 'https://localhost:44349/api/auth/signin';
            let oData = {
                Login,
                Password
            };
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        if (response.data.access_token) window.location.href = 'https://localhost:44349/back-office'

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