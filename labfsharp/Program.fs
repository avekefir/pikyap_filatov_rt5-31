open System

// lab1
let tryParseDouble (input: string) =
    match Double.TryParse(input) with
    | (true, num) -> Some num
    | _ -> None

let read_coef_cons coefficientName isA =
    let rec readLoop () =
        printf $"\nВведите коэффициент {coefficientName}: "
        let input = Console.ReadLine()
        match tryParseDouble input with
        | Some num -> 
            if isA && num = 0.0 then
                printfn "Коэффициент A не может быть равен 0 для биквадратного уравнения."
                printfn "Пожалуйста, введите ненулевое значение для A."
                readLoop ()
            else
                num
        | None -> 
            printf "Некорректный ввод. Пожалуйста, введите действительное число."
            readLoop ()
    readLoop ()

let get_coef_cons () =
    printfn "\nВведите коэффициенты биквадратного уравнения Ax^4 + Bx^2 + C = 0"
    let a = read_coef_cons "A" true
    let b = read_coef_cons "B" false
    let c = read_coef_cons "C" false
    (a, b, c)

let solve_biquadratic a b c =
    let discriminant = b * b - 4.0 * a * c
    
    if discriminant < 0.0 then
        []
    else
        let t1 = (-b + sqrt discriminant) / (2.0 * a)
        let t2 = (-b - sqrt discriminant) / (2.0 * a)
        
        let mutable roots = []
        
        if t1 >= 0.0 then
            let root1 = sqrt t1
            let root2 = -sqrt t1
            roots <- root1 :: root2 :: roots
        
        if t2 >= 0.0 then
            let root3 = sqrt t2
            let root4 = -sqrt t2
            roots <- root3 :: root4 :: roots
        roots |> List.distinct

let printColor color text =
    let currentColor = Console.ForegroundColor
    Console.ForegroundColor <- color
    printfn "%s" text
    Console.ForegroundColor <- currentColor

let parseCommandLineArgs (args: string[]) =
    if args.Length < 3 then
        None
    else
        match tryParseDouble args.[0], tryParseDouble args.[1], tryParseDouble args.[2] with
        | Some a, Some b, Some c -> 
            if a = 0.0 then
                printColor ConsoleColor.Yellow "Ошибка: коэффициент A = 0, уравнение не является биквадратным."
                printColor ConsoleColor.Yellow "Необходимо ввести коэффициенты с клавиатуры."
                None
            else
                Some (a, b, c)
        | _ -> None

// lab2
type GeometricFigureDU =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float

let calculateArea figure =
    match figure with
    | Rectangle(w, h) -> w * h
    | Square(s) -> s * s
    | Circle(r) -> Math.PI * r * r

let printFigure figure =
    let area = calculateArea figure
    match figure with
    | Rectangle(w, h) -> 
        printfn "Прямоугольник: ширина = %.2f, высота = %.2f, площадь = %.2f" w h area
    | Square(s) -> 
        printfn "Квадрат: сторона = %.2f, площадь = %.2f" s area
    | Circle(r) -> 
        printfn "Круг: радиус = %.2f, площадь = %.2f" r area

[<EntryPoint>]
let main argv =
    // lab1
    printfn "Лабораторная работа #1"
    let a, b, c =
        match parseCommandLineArgs argv with
        | Some (a, b, c) ->
            printfn "A = %f, B = %f, C = %f" a b c
            (a, b, c)
        | None ->
            get_coef_cons ()
    
    printfn "\nРешение биквадратного уравнения: %fx^4 + %fx^2 + %f = 0" a b c
    let roots = solve_biquadratic a b c
    if List.isEmpty roots then
        printColor ConsoleColor.Red "Действительных корней нет."
    else
        printColor ConsoleColor.Green "Найденные корни:"
        roots |> List.iter (fun root -> 
            printColor ConsoleColor.Green (sprintf "x = %f" root))


    // lab2
    let rectDU = Rectangle(10, 20)
    let squareDU = Square(5)
    let circleDU = Circle(15)

    printfn "Лабораторная работа #2"
    printFigure rectDU
    printFigure squareDU
    printFigure circleDU

    0