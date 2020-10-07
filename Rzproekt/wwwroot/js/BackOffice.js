"use strict";

var back_office = new Vue({
	el: "#back_office",
	data() {
		return {
			files: ""
		}
	},
	methods: {
		// Функция отправляет изображения.
		submitFile() {
			let sUrl = "https://localhost:44349/api/back-office/upload-image";
			let formData = new FormData();

			for (var i = 0; i < this.files.length; i++) {
				let file = this.files[i];
				formData.set('files[' + i + ']', file);
			}

			try {
				axios.post(sUrl, formData,
					{
						headers: {
							'Content-Type': 'multipart/form-data'
						}
					}
				).then(function () {
					console.log('SUCCESS!!');
				})
					.catch(function () {
						console.log('FAILURE!!');
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция собирает файлы.
		handleFilesUpload() {
			this.files = this.$refs.files.files;
		}
	}
});