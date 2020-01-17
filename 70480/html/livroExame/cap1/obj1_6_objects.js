//inline object
var book = {
				ISBN: "55555555",
				Length: 560,
				genre: "programming",
				covering: "soft",
				author: "John Doe",
				currentPage: 5,
				title: "My Big Book of Wonderful Things",
				
				flipTo: function flipToAPage(pNum) {
					this.currentPage = pNum;
				},
				turnPageForward: function turnForward() {
					this.flipTo(this.currentPage++);
				},
				turnPageBackward: function turnBackward() {
					this.flipTo(this.currentPage--);
				}
			}	
			
//This line throws an exception because the object does not support this method
book.FlipToAPage(15);
//This line works because this is what the method has been named.
book.flipTo(15);

//Prototype object
function Book() {
					this.ISBN = "55555555";
					this.Length = 560;
					this.genre= "programming";
					this.covering = "soft";
					this.author = "John Doe";
					this.currentPage = 5,
					
					this.flipTo = function FlipToAPage(pNum) {
						this.currentPage = pNum;
					},
					this.turnPageForward = function turnForward() {
						this.flipTo(this.currentPage++);
					},
					this.turnPageBackward = function turnBackward() {
						this.flipTo(this.currentPage--);
					}
				}
var books = new Array(new Book(), new Book(), new Book());
books[0].Length

//Prototype object with constructor
function Book()
{
//just creates an empty book.
}
function Book(title, length, author) {
	this.title = title;
	this.Length = length;
	this.author = author;
}
Book.prototype = {
	ISBN: "",
	Length: -1,
	genre: "",
	covering: "",
	author: "",
	currentPage: 0,
	title: "",
	flipTo: function FlipToAPage(pNum) {
		this.currentPage = pNum;
	},
	turnPageForward: function turnForward() {
		this.flipTo(this.currentPage++);
	},
	turnPageBackward: function turnBackward() {
		this.flipTo(this.currentPage--);
	}
};
var books = new Array(new Book(), new Book("First Edition",350,"Random"));

//agregação
Book.prototype = {
	ISBN: "",
	Length: -1,
	genre: "",
	covering: "",
	author: new Author(),
	currentPage: 0,
	title: "",
	//…
}
function Author(){
}
function Author(firstName, lastName, gender)
{
	this.firstName = firstName;
	this.lastName = lastName;
	this.gender = gender;
}
Author.prototype = {
	firstName:"",
	lastName:"",
	gender:"",
	BookCount: 0
}
var books = new Array(new Book(),
new Book("First Edition",350, new Author("Random","Author","M"))
);

//Herança in line
var popupBook = Object.create(Book.protoType,{ hasSound: {value:true},
												showPopUp:{ value: function showPop() {
												//do logic to show a popup
												}
												}
											});

//Herança prototype
function PopUpBook() {
Book.call(this);
}
PopUpBook.prototype = Book.prototype;
PopUpBook.prototype.hasSound = false;
PopUpBook.prototype.showPopUp = function ShowPop() { };											

///////////////////////////////////////////////
Array.prototype.sum = function () {
var res = 0;
for (var i = 0; i < this.length; i++)
res += this[i];
return res;
};
var x = new Array(2);
x[0] = 5;
x[1] = 6;
document.write(x.sum());