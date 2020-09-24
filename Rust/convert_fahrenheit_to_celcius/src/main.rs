use std::io;

fn main() {
    let mut user_input = String::new();

    println!("====================================");
    println!("=CONVERSOR DE FAHRENHEIT TO CELCIUS=");
    println!("====================================");
    println!("");


    println!("Digite a temperatura para conversão:");
    io::stdin()
        .read_line(&mut user_input)
        .expect("Failed to read line");

    let user_input: f64 = match user_input.trim().parse(){
        Ok(num) => num,
        Err(_) => return,
    };


    let celcius = convert_fahrenheit_to_celcius(user_input);

    println!("{}°F corresponde à {}°C",user_input, celcius);
}


fn convert_fahrenheit_to_celcius(degree_in_fahrenheit :f64) ->f64{
    (degree_in_fahrenheit - 32.0) * 5.0/9.0
}
