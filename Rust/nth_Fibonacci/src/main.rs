use std::io;

fn main() {
    
    let mut user_input = String::new();

    println!("================================================");
    println!("=LOOK THE Nth ELEMENT OF FIBONACCI'S SEQUENCE  =");
    println!("================================================");
    println!("");


    println!("Digite qual elemento voê que ver:");
    io::stdin()
        .read_line(&mut user_input)
        .expect("Failed to read line");

    let user_input: u16 = match user_input.trim().parse(){
        Ok(num) => num,
        Err(_) => return,
    };
    
    
    let fibonacci_number = nth_fibonacci(user_input);
    println!("O {}th elemento da sequencia é: {}",user_input, fibonacci_number);
}

fn nth_fibonacci(nth_number :u16) -> u16
{
    let mut number = 0;

    let mut anterior = 1;
    let mut atual = 1;

    let mut i = 1;
    while i <= nth_number 
    {
        number = anterior + atual;
        anterior = atual;
        atual = number;

        i +=1;
    }
    number
}
