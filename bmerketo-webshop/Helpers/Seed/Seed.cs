using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace bmerketo_webshop.Helpers.Seed;

public class Seed
{
    private readonly WebshopContext _context;

    public Seed(WebshopContext context)
    {
        _context = context;
    }

    public async Task SeedAll()
    {

        await SeedCategories();
        await SeedProducts();
        await SeedTags();
        await SeedProductTags();
    }


    private async Task SeedCategories()
    {
        if (await _context.Categories.AnyAsync())
            return;

        var categories = new List<CategoryEntity>
            {
                new CategoryEntity { CategoryName = "Computers" },
                new CategoryEntity { CategoryName = "Mobile Devices" },
                new CategoryEntity { CategoryName = "Gaming Consoles" },
                new CategoryEntity { CategoryName = "Computer Parts" },
                new CategoryEntity { CategoryName = "Software" },
                new CategoryEntity { CategoryName = "Other" }
            };

        _context.Categories.AddRange(categories);
        await _context.SaveChangesAsync();
    }

    private async Task SeedProducts()
    {
        if (await _context.Products.AnyAsync())
            return;

        var products = new List<ProductEntity>
        {
            new ProductEntity
            {
                ArticleId = "GRP454354346",
                Name = "ASOS ROG Ally",
                Description = "Handheld gaming computer for all your games. ASUS ROG Ally is a powerful and handheld gaming computer with a 120Hz FHD display and performance that delivers an unbeatable gaming experience. With an ergonomic design and a lightweight of 608g, you can easily take it anywhere. ROG Ally comes with Windows 11 and can run games from all major game stores such as Steam, Xbox Game Pass, Epic, and GOG.",
                CurrentPrice = 949,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1
            },
            new ProductEntity
            {
                ArticleId = "XYZ534543123",
                Name = "Apple iPhone 13",
                Description = "The latest iPhone with an A15 Bionic chip, Super Retina XDR display, and advanced dual-camera system. Experience the power and innovation of iPhone 13.",
                CurrentPrice = 999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2
            },
            new ProductEntity
            {
                ArticleId = "ABC78534534539",
                Name = "Nintendo Switch",
                Description = "A versatile gaming console that allows you to play games on your TV or take them on the go. Enjoy a wide range of Nintendo exclusive titles and popular third-party games.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3
            },
            new ProductEntity
            {
                ArticleId = "PQR553453467",
                Name = "Logitech G Pro Mechanical Keyboard",
                Description = "A high-performance mechanical keyboard designed for professional gamers. Features customizable RGB lighting, programmable macros, and responsive mechanical switches.",
                CurrentPrice = 149,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4
            },
            new ProductEntity
            {
                ArticleId = "ABC153453423",
                Name = "Dell XPS 15",
                Description = "A high-performance laptop with a stunning 4K OLED display and powerful hardware. Ideal for productivity and content creation tasks.",
                CurrentPrice = 1899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1
            },
            new ProductEntity
            {
                ArticleId = "XY543Z7543589",
                Name = "Sony PlayStation 5",
                Description = "The next-generation gaming console with ultra-fast SSD, ray tracing, and immersive gaming experiences. Enjoy a wide range of exclusive PlayStation games.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3
            },
            new ProductEntity
            {
                ArticleId = "P543543QR4578676",
                Name = "AMD Ryzen 9 5900X",
                Description = "A powerful desktop processor with 12 cores and 24 threads. Offers exceptional performance for gaming and demanding multi-threaded tasks.",
                CurrentPrice = 549,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4
            },
            new ProductEntity
            {
                ArticleId = "MNO15323823",
                Name = "Samsung Odyssey G9",
                Description = "An ultra-wide gaming monitor with a 49-inch curved QLED display and 240Hz refresh rate. Get a truly immersive gaming experience with high-quality visuals.",
                CurrentPrice = 1499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4
            },
            new ProductEntity
            {
                ArticleId = "ART1254884533",
                Name = "Samsung Galaxy S21",
                Description = "A flagship smartphone with a stunning display, powerful camera system, and 5G connectivity. Experience the latest features and innovations from Samsung.",
                CurrentPrice = 999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART477967423356",
                Name = "Apple MacBook Pro",
                Description = "A high-performance laptop with a Retina display, powerful hardware, and all-day battery life. Perfect for professionals and creative individuals.",
                CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART76587543489",
                Name = "Sony PlayStation 5",
                Description = "The next-generation gaming console with ultra-fast SSD, ray tracing, and immersive gaming experiences. Enjoy a wide range of exclusive PlayStation games.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART16565894011",
                Name = "LG UltraWide Monitor",
                Description = "An ultra-wide monitor with a 34-inch curved display and QHD resolution. Perfect for multitasking and immersive gaming experiences.",
                CurrentPrice = 699,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART12687534413",
                Name = "Nintendo Switch Lite",
                Description = "A handheld gaming console that allows you to play your favorite Nintendo games on the go. Enjoy a wide range of fun and entertaining titles.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART78753391415",
                Name = "Logitech G Pro Mechanical Keyboard",
                Description = "A high-performance mechanical keyboard designed for gamers and professionals. Features responsive switches and customizable RGB lighting.",
                CurrentPrice = 129,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART16212334455617",
                Name = "Samsung 4K QLED TV",
                Description = "A stunning 4K QLED TV with HDR support and Smart TV capabilities. Enjoy vibrant colors and immersive viewing experiences at home.",
                CurrentPrice = 1299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Other category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "AR34675643T1819",
                Name = "Bose QuietComfort 35 II",
                Description = "Wireless noise-canceling headphones with superior sound quality and comfortable design. Enjoy immersive audio and block out distractions.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART266423772344021",
                Name = "WD My Passport Portable SSD",
                Description = "A compact and fast portable SSD with high-speed data transfers and ample storage capacity. Keep your files and data securely stored and easily accessible.",
                CurrentPrice = 159,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Storage Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART2654764223",
                Name = "Canon EOS Rebel T7i",
                Description = "A versatile DSLR camera with a high-resolution sensor and advanced autofocus system. Capture stunning photos and videos with ease.",
                CurrentPrice = 899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART2645623356759425",
                Name = "Apple AirPods Pro",
                Description = "Wireless earbuds with active noise cancellation and immersive sound. Enjoy a seamless audio experience and easy pairing with Apple devices.",
                CurrentPrice = 249,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "AR65464765743454T2627",
                Name = "Samsung Galaxy Tab S7+",
                Description = "A premium Android tablet with a stunning display, powerful hardware, and S Pen support. Ideal for productivity and entertainment on the go.",
                CurrentPrice = 849,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Tablets category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART677634534562829",
                Name = "Razer Huntsman Elite Gaming Keyboard",
                Description = "A high-performance gaming keyboard with optical switches for ultra-fast response times. Features customizable RGB lighting and durable construction.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART30654345344731",
                Name = "Sony WH-1000XM4 Wireless Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and high-quality audio. Enjoy long-lasting comfort and immersive sound.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART327645745353433",
                Name = "Nintendo Switch Pro Controller",
                Description = "A high-quality game controller designed for the Nintendo Switch console. Enjoy enhanced control and precision for your gaming sessions.",
                CurrentPrice = 69,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART353453767888435",
                Name = "Microsoft Surface Laptop 4",
                Description = "A sleek and lightweight laptop with a high-resolution touchscreen and powerful performance. Perfect for work and entertainment on the go.",
                CurrentPrice = 1299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART65456455553637",
                Name = "LG OLED CX Series TV",
                Description = "A premium OLED TV with stunning picture quality and smart features. Enjoy deep blacks, vibrant colors, and an immersive viewing experience.",
                CurrentPrice = 1999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Other category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART3866654363455539",
                Name = "Logitech C920 HD Pro Webcam",
                Description = "A high-definition webcam with crisp video quality and built-in stereo microphones. Ideal for video conferencing, streaming, and content creation.",
                CurrentPrice =79,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART6546477884041",
                Name = "Corsair Vengeance RGB Pro RAM",
                Description = "High-performance DDR4 RAM modules with vibrant RGB lighting. Enhance your system's performance and aesthetics with reliable memory.",
                CurrentPrice = 129,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART42767765456456643",
                Name = "Google Nest Hub",
                Description = "A smart display with the Google Assistant built-in. Control your smart home devices, get answers, and enjoy multimedia content with voice commands.",
                CurrentPrice = 99,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Smart Home category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART65645454445",
                Name = "Dell XPS 13 Laptop",
                Description = "A sleek and powerful laptop with a compact design and stunning display. Experience exceptional performance and portability.",
                CurrentPrice = 1299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART464444327",
                Name = "Samsung Odyssey G7 Gaming Monitor",
                Description = "A curved gaming monitor with a high refresh rate and QLED technology. Immerse yourself in smooth gameplay and vibrant visuals.",
                CurrentPrice = 799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART433336849",
                Name = "Apple Watch Series 7",
                Description = "A stylish smartwatch with advanced health and fitness features. Stay connected, track your workouts, and monitor your well-being.",
                CurrentPrice = 399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Wearable Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART50654851",
                Name = "Sony WH-1000XM4 Wireless Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and high-quality audio. Enjoy long-lasting comfort and immersive sound.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART526545553",
                Name = "Canon EOS R5 Mirrorless Camera",
                Description = "A professional-grade mirrorless camera with high-resolution imaging and advanced video capabilities. Capture stunning photos and videos with ease.",
                CurrentPrice = 3899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART546543355",
                Name = "Razer BlackWidow Elite Mechanical Keyboard",
                Description = "A premium mechanical keyboard designed for gaming enthusiasts. Features customizable RGB lighting and programmable keys for personalized gaming experiences.",
                CurrentPrice = 169,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART565654667",
                Name = "LG CX OLED TV",
                Description = "A flagship OLED TV with exceptional picture quality and smart features. Enjoy cinematic visuals and immersive entertainment at home.",
                CurrentPrice = 2499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Other category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART58655559",
                Name = "Bose SoundLink Revolve+ Bluetooth Speaker",
                Description = "A portable Bluetooth speaker with 360-degree sound and long battery life. Enjoy high-quality audio wherever you go.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART6066546656651",
            Name = "Microsoft Surface Pro 8",
            Description = "A versatile 2-in-1 device with a detachable keyboard and pen support. Experience the power of a laptop and the flexibility of a tablet.",
            CurrentPrice = 1299,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART6254343223163",
            Name = "Logitech G502 HERO Gaming Mouse",
            Description = "A high-performance gaming mouse with customizable features and precise tracking. Gain an edge in your gaming sessions.",
            CurrentPrice = 79,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART64895445465",
                Name = "Sony PlayStation 5",
                Description = "Next-generation gaming console with powerful hardware and immersive gaming experiences. Enjoy stunning graphics and fast load times.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART66675546775434667",
                Name = "Samsung Galaxy S21 Ultra",
                Description = "Flagship smartphone with a stunning display, powerful camera system, and premium features. Experience cutting-edge technology at your fingertips.",
                CurrentPrice = 1199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART68666446659",
                Name = "HP Spectre x360 Convertible Laptop",
                Description = "A versatile and stylish laptop with a 360-degree hinge and touch-enabled display. Experience the power of performance and flexibility.",
                CurrentPrice = 1399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART745446799071",
                Name = "Bose QuietComfort 35 II Wireless Headphones",
                Description = "Premium wireless headphones with world-class noise cancellation and exceptional sound quality. Enjoy a peaceful and immersive audio experience.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART7255775573",
                Name = "Logitech G923 Racing Wheel",
                Description = "A high-performance racing wheel for an immersive driving experience. Feel every turn and sensation on the virtual track.",
                CurrentPrice = 399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Gaming Accessories category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART746654545675",
                Name = "Apple MacBook Pro",
                Description = "Powerful and portable laptop for professionals and creative individuals. Experience exceptional performance and stunning Retina display.",
                CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART76654567877",
                Name = "NVIDIA GeForce RTX 3080",
                Description = "A high-end graphics card for cutting-edge gaming and realistic graphics. Experience smooth gameplay and stunning visual effects.",
                CurrentPrice = 699,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART7834345579",
                Name = "Amazon Echo Show 10",
                Description = "A smart display with a rotating screen and built-in Alexa voice assistant. Stay connected, control your smart home, and enjoy multimedia content.",
                CurrentPrice = 249,
                ImageUrl = "/images/placeholders/625x647.png",CategoryId = 6 // Smart Home category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART8065487643281",
            Name = "GoPro Hero 9 Black",
            Description = "A versatile action camera with high-resolution video and advanced features. Capture your adventures in stunning detail.",
            CurrentPrice = 349,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART4435656787568283",
            Name = "Microsoft Xbox Series X",
            Description = "Next-generation gaming console with powerful hardware and backward compatibility. Immerse yourself in gaming worlds like never before.",
            CurrentPrice = 499,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART856756754378485",
                Name = "Samsung 34-Inch Ultrawide Monitor",
                Description = "An immersive ultrawide monitor with a curved display and vibrant colors. Enhance your productivity and gaming experience.",
                CurrentPrice = 799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART867652335787",
                Name = "Apple iPad Pro",
                Description = "A powerful and versatile tablet for work and creativity. Experience a stunning display, advanced performance, and Apple Pencil support.",
                CurrentPrice = 999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART887645654589",
                Name = "Corsair K95 RGB Platinum Mechanical Gaming Keyboard",
                Description = "A high-performance mechanical gaming keyboard with customizable RGB lighting and advanced features. Dominate your gaming sessions with precision and style.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART909654656451",
                Name = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and exceptional audio quality. Immerse yourself in your favorite music without distractions.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART92654666693",
                Name = "Razer Blade 15 Gaming Laptop",
                Description = "A high-performance gaming laptop with a sleek design and powerful specifications. Enjoy smooth gameplay and stunning visuals on the go.",
                CurrentPrice = 1999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART96546677495",
                Name = "Nintendo Switch",
                Description = "A versatile gaming console for at-home and on-the-go gaming experiences. Play your favorite games anytime, anywhere.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART9697654457",
                Name = "DJI Mavic Air 2 Drone",
                Description = "A compact and powerful drone with advanced features for aerial photography and videography. Capture stunning shots from a new perspective.",
                CurrentPrice = 799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Drones category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART9897657779",
                Name = "Logitech C920 HD Pro Webcam",
                Description = "A high-definition webcam with crisp video quality and built-in microphone. Perfect for video conferences, live streaming, and content creation.",
                CurrentPrice = 79,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART76577731011",
                Name = "Anker PowerCore 26800 Portable Charger",
                Description = "A high-capacity portable charger to keep your devices powered on the go. Charge smartphones, tablets, and other USB devices multiple times.",
                CurrentPrice = 59,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Accessories category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART121345456765fg3",
                Name = "LG CX Series 65-Inch OLED TV",
                Description = "An OLED TV with stunning picture quality, deep blacks, and vibrant colors. Experience true cinematic visuals in the comfort of your home.",
                CurrentPrice = 2499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART1416546452234785",
                Name = "Canon EOS R5 Mirrorless Camera",
                Description = "A professional-grade mirrorless camera with high-resolution imaging and advanced features. Capture stunning photos and videos with exceptional detail.",
                CurrentPrice = 3899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART16345479082117",
                Name = "Samsung Odyssey G9 Gaming Monitor",
                Description = "A curved gaming monitor with a massive 49-inch display and ultra-wide aspect ratio. Immerse yourself in gaming with stunning visuals.",
                CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART1384948329819",
                Name = "Apple AirPods Pro",
                Description = "Wireless earbuds with active noise cancellation and immersive sound. Enjoy a premium audio experience with a comfortable and customizable fit.",
                CurrentPrice = 249,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART202142366754",
                Name = "Dell XPS 15 Laptop",
                Description = "A high-performance laptop with a stunning display and powerful specifications. Experience exceptional performance for demanding tasks and multimedia.",
                CurrentPrice = 1899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART222432345667334",
                Name = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and exceptional sound quality. Immerse yourself in your favorite music.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART24254353432235",
                Name = "Razer Huntsman Elite Gaming Keyboard",
                Description = "A high-performance gaming keyboard with opto-mechanical switches and customizable RGB lighting. Enjoy precise and responsive keystrokes.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART2625435676889437",
                Name = "Bose SoundLink Revolve+ Portable Bluetooth Speaker",
                Description = "A portable Bluetooth speaker with 360-degree sound and long battery life. Enjoy your favorite music with rich and immersive audio.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART2544445665829",
                Name = "Logitech MX Master 3 Wireless Mouse",
                Description = "An advanced wireless mouse with customizable buttons and precise tracking. Boost your productivity and navigate with ease.",
                CurrentPrice = 99,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART306567775531",
            Name = "Samsung Galaxy Tab S7+",
            Description = "A versatile and powerful tablet with a stunning display and S Pen support. Experience productivity and entertainment on the go.",
            CurrentPrice = 849,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "AR6565456T3233",
            Name = "LG CX Series 55-Inch OLED TV",
            Description = "An OLED TV with stunning picture quality, deep blacks, and vibrant colors. Enjoy cinematic visuals and immersive entertainment.",
            CurrentPrice = 1499,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "65464566ART354435",
                Name = "NVIDIA GeForce RTX 3080 Graphics Card",
                Description = "A high-performance graphics card for gaming and content creation. Experience realistic visuals and smooth gameplay.",
                CurrentPrice = 799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "AR654645T3637",
                Name = "Sony PlayStation 5",
                Description = "The latest gaming console with cutting-edge features and next-gen gaming experiences. Dive into immersive gaming adventures.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "645645RT385439",
                Name = "Bose QuietComfort 35 II Wireless Headphones",
                Description = "Premium wireless headphones with renowned noise cancellation technology. Enjoy immersive sound and comfort for all-day listening.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART40767867875641",
                Name = "Apple MacBook Pro 16-Inch",
                Description = "A powerful and sleek laptop for professionals and creatives. Experience stunning visuals and enhanced performance.",
                CurrentPrice = 2399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART42342525454243",
                Name = "Samsung Galaxy S21 Ultra",
                Description = "A flagship smartphone with a stunning display and advanced camera system. Capture pro-grade photos and 8K videos.",
                CurrentPrice = 1199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART6543534253564445",
                Name = "Logitech G Pro X Gaming Headset",
                Description = "A professional-grade gaming headset with advanced audio technology and customizable features. Immerse yourself in precise and immersive sound.",
                CurrentPrice = 129,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "A63455436RT4647",
                Name = "Samsung QLED 75-Inch 4K Smart TV",
                Description = "A large-screen 4K smart TV with vibrant colors and stunning picture quality. Enjoy a cinematic viewing experience at home.",
                CurrentPrice = 2499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART4849653534",
                Name = "Microsoft Surface Laptop 4",
                Description = "A sleek and powerful laptop for productivity and creativity. Experience a premium design and seamless performance.",
                CurrentPrice = 1299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART507878787851",
                Name = "Amazon Echo Dot (4th Generation)",
                Description = "A compact and smart speaker with Alexa voice assistant. Control your smart home and enjoy music and hands-free convenience.",
                CurrentPrice = 49,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Smart Home Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART52212121253",
                Name = "GoPro HERO9 Black",
                Description = "A high-quality action camera with 5K video and advanced stabilization. Capture your adventures in stunning detail.",
                CurrentPrice = 449,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART54323232355",
                Name = "LG UltraGear 27-Inch Gaming Monitor",
                Description = "A high-performance gaming monitor with a fast refresh rate and responsive gameplay. Immerse yourself in smooth and vibrant visuals.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART54343443657",
                Name = "Apple iPad Air",
                Description = "A versatile tablet with a powerful A14 Bionic chip and stunning Retina display. Enjoy productivity and entertainment on the go.",
                CurrentPrice = 599,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART585454544559",
                Name = "Corsair K95 RGB Platinum XT Mechanical Gaming Keyboard",
                Description = "A premium gaming keyboard with customizable RGB lighting and Cherry MX switches. Experience precise and responsive keystrokes.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART6065656561",
                Name = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and exceptional sound quality. Immerse yourself in your favorite music.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART6276767663",
                Name = "DJI Mavic Air 2 Drone",
                Description = "A compact and powerful drone with 4K video and intelligent features. Capture stunning aerial footage and unleash your creativity.",
                CurrentPrice = 799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Drones category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART68787878465",
                Name = "Samsung Odyssey G9 Gaming Monitor",
                Description = "A curved gaming monitor with a massive 49-inch display and ultra-wide aspect ratio. Immerse yourself in gaming with stunning visuals.",
                CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART669898989867",
                Name = "Bose SoundLink Revolve+ Portable Bluetooth Speaker",
                Description = "A portable Bluetooth speaker with 360-degree sound and long battery life. Enjoy your favorite music with rich and immersive audio.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART6869090909",
                Name = "Microsoft Surface Book 3",
                Description = "A versatile laptop with a detachable touchscreen and powerful performance. Switch between laptop and tablet mode for maximum productivity.", CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "21212ART7071",
                Name = "Apple Watch Series 7",
                Description = "A smartwatch with advanced health and fitness features. Stay connected and track your activity with style and convenience.",
                CurrentPrice = 399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "323232ART7273",
                Name = "Razer Huntsman Elite Gaming Keyboard",
                Description = "A premium gaming keyboard with ultra-fast opto-mechanical switches and customizable RGB lighting. Elevate your gaming experience.",
                CurrentPrice = 199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "434343ART7475",
                Name = "Canon EOS R5 Mirrorless Camera",
                Description = "A professional-grade mirrorless camera with exceptional image quality and advanced video capabilities. Capture stunning photos and 8K videos.",
                CurrentPrice = 3899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "54545454ART7677",
                Name = "Microsoft Xbox Series X",
                Description = "The next-generation gaming console with powerful hardware and immersive gaming experiences. Enjoy stunning graphics and fast load times.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "65656565ART7879",
                Name = "Dell UltraSharp U2720Q 27-Inch Monitor",
                Description = "A high-quality 4K monitor with accurate colors and a sleek design. Enhance your productivity and multimedia experiences.",
                CurrentPrice = 599,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "8787878ART8081",
                Name = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and exceptional sound quality. Immerse yourself in your favorite music.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "989898ART8283",
                Name = "Samsung Galaxy Tab S7+",
                Description = "A high-performance Android tablet with a stunning display and versatile functionality. Enjoy productivity and entertainment on the go.",
                CurrentPrice = 849,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "090909ART8485",
                Name = "Logitech G502 HERO Gaming Mouse",
                Description = "A high-precision gaming mouse with customizable features and advanced tracking technology. Dominate your gaming sessions.",
                CurrentPrice = 79,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "A2121212RT8687",
                Name = "LG OLED CX Series 65-Inch 4K Smart TV",
                Description = "A premium OLED TV with deep blacks and vibrant colors. Enjoy a cinematic viewing experience and access to smart features.",
                CurrentPrice = 2199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "AR323232T8889",
                Name = "Fitbit Versa 3 Smartwatch",
                Description = "A versatile smartwatch with fitness tracking and advanced health features. Stay connected and motivated on your wellness journey.", CurrentPrice = 229,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "AR5454545T9091",
                Name = "ASUS ROG Strix GeForce RTX 3080 Gaming Graphics Card",
                Description = "A high-performance graphics card for gaming enthusiasts. Experience realistic visuals and smooth gameplay.",
                CurrentPrice = 1499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART656565659293",
                Name = "Bose QuietComfort 35 II Wireless Headphones",
                Description = "Premium wireless headphones with renowned noise cancellation and balanced sound quality. Enjoy your music in peace and comfort.",
                CurrentPrice = 299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART878787879495",
                Name = "Apple MacBook Pro 16-Inch",
                Description = "A powerful and sleek laptop with a stunning Retina display and advanced performance. Perfect for professionals and creative enthusiasts.",
                CurrentPrice = 2399,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART9898989697",
                Name = "Samsung Galaxy S21 Ultra",
                Description = "A premium flagship smartphone with a powerful camera system and a stunning display. Experience the pinnacle of mobile technology.",
                CurrentPrice = 1199,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART9898989899",
                Name = "Logitech G Pro X Gaming Headset",
                Description = "A professional-grade gaming headset with advanced audio technologies and customizable features. Immerse yourself in virtual worlds.",
                CurrentPrice = 129,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART0909090011",
                Name = "Sony PlayStation 5",
                Description = "The next-generation gaming console with cutting-edge hardware and immersive gaming experiences. Enter a new era of gaming.",
                CurrentPrice = 499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART021212121213",
                Name = "DJI Phantom 4 Pro V2.0 Drone",
                Description = "A professional-grade drone with a powerful camera and intelligent flight modes. Capture breathtaking aerial photos and videos.",
                CurrentPrice = 1799,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 5 // Drones category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART043232323215",
                Name = "LG CX Series 77-Inch 4K OLED Smart TV",
                Description = "A premium OLED TV with stunning picture quality and smart features. Enjoy a cinematic viewing experience at home.",
                CurrentPrice = 3499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART0654545417",
                Name = "Razer Blade 15 Gaming Laptop",
                Description = "A high-performance gaming laptop with a sleek design and powerful hardware. Take your gaming to the next level.",
                CurrentPrice = 1899,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART08656565619",
                Name = "JBL Charge 4 Portable Bluetooth Speaker",
                Description = "A portable Bluetooth speaker with powerful sound and long battery life. Take your music anywhere you go.",
                CurrentPrice = 139,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART1076767621",
            Name = "Microsoft Surface Pro 7",
            Description = "A versatile 2-in-1 laptop with a detachable keyboard and touchscreen. Stay productive and creative on the go.",
            CurrentPrice = 899,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
            ArticleId = "ART1287878723",
            Name = "Nintendo Switch Lite",
            Description = "A handheld gaming console for on-the-go gaming. Enjoy a vast library of Nintendo games in a compact and portable form.",
            CurrentPrice = 199,
            ImageUrl = "/images/placeholders/625x647.png",
            CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART14989899825",
                Name = "Apple iPad Pro (12.9-inch)",
                Description = "A powerful and versatile tablet with a stunning Liquid Retina display and advanced performance. Perfect for productivity and creativity.",
                CurrentPrice = 1099,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 2 // Mobile Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART160909090927",
                Name = "Samsung Odyssey G9 Curved Gaming Monitor",
                Description = "An ultra-wide gaming monitor with a massive 49-inch curved display and immersive QLED technology. Experience gaming like never before.",
                CurrentPrice = 1499,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART113223547829",
                Name = "Sony WH-1000XM4 Wireless Noise-Canceling Headphones",
                Description = "Premium wireless headphones with industry-leading noise cancellation and exceptional sound quality. Immerse yourself in your favorite music.",
                CurrentPrice = 349,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART24366778679031",
                Name = "GoPro Hero 9 Black",
                Description = "A high-quality action camera with 5K video recording and advanced stabilization. Capture your adventures with stunning details.",
                CurrentPrice = 449,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Cameras category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART25435344566233",
                Name = "Alienware Aurora R12 Gaming Desktop",
                Description = "A powerful gaming desktop with cutting-edge hardware and customizable features. Dominate your gaming sessions with top-notch performance.",
                CurrentPrice = 1999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART2454356789835",
                Name = "Bose QuietComfort Earbuds",
                Description = "Premium true wireless earbuds with renowned noise cancellation and immersive sound. Enjoy your music with exceptional clarity.",
                CurrentPrice = 279,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // Audio Devices category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART266534432324236637",
                Name = "LG C1 Series 55-Inch 4K OLED Smart TV",
                Description = "A premium OLED TV with stunning picture quality and smart features. Enjoy a cinematic viewing experience at home.",
                CurrentPrice = 1999,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 6 // TVs category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART28787568674332339",
                Name = "Microsoft Surface Laptop 4",
                Description = "A sleek and powerful laptop with a vibrant PixelSense touchscreen and long battery life. Perfect for work and entertainment.",
                CurrentPrice = 1299,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 1 // Computers category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART3045356534765841",
                Name = "Logitech MX Master 3 Wireless Mouse",
                Description = "An advanced wireless mouse with ergonomic design and customizable controls. Enhance your productivity and workflow.",
                CurrentPrice = 99,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 4 // Computer Parts category (replace with the desired category ID)
            },
            new ProductEntity
            {
                ArticleId = "ART3245434534647878563",
                Name = "Nintendo Switch Pro Controller",
                Description = "A high-quality gamepad for the Nintendo Switch console. Enjoy precise controls and comfortable gaming sessions.",
                CurrentPrice = 69,
                ImageUrl = "/images/placeholders/625x647.png",
                CategoryId = 3 // Gaming Consoles category (replace with the desired category ID)
            }
        };

        await _context.Products.AddRangeAsync(products);
        await _context.SaveChangesAsync();
    }
    private async Task SeedTags()
    {
        if (await _context.Tags.AnyAsync())
            return;

        var tags = new List<TagEntity>
        {
            new TagEntity
            {
                TagName = "Featured"
            },
            new TagEntity
            {
                TagName = "On Sale"
            },
            new TagEntity
            {
                TagName = "Top Seller"
            },
            new TagEntity
            {
                TagName = "New"
            },
            new TagEntity
            {
                TagName = "Best Collection"
            }
        };

        await _context.Tags.AddRangeAsync(tags);
        await _context.SaveChangesAsync();
    }

    private async Task SeedProductTags()
    {
        if (await _context.ProductsTags.AnyAsync())
            return;

        var productTags = new List<ProductsTagsEntity>
        {
            // Featured items. Will be displayed in jumbotron on home page.
            new ProductsTagsEntity
            {
                ProductArticleNumber = "434343ART7475",
                TagId = 1
            },
            new ProductsTagsEntity
            {
                ProductArticleNumber = "54545454ART7677",
                TagId = 1
            },
            new ProductsTagsEntity
            {
                ProductArticleNumber = "AR654645T3637",
                TagId = 1
            },
            new ProductsTagsEntity
            {
                ProductArticleNumber = "ART1287878723",
                TagId = 1
            },

            // On sale
            new ProductsTagsEntity
            {
                ProductArticleNumber = "XY543Z7543589",
                TagId = 2
            },
            new ProductsTagsEntity
            {
                ProductArticleNumber = "XYZ534543123",
                TagId = 2
            },
        };

        var bestCollectionProducts = await _context.Products.Take(32).ToListAsync();
        var topSellersProducts = await _context.Products.Skip(32).Take(32).ToListAsync();
        var newProducts = await _context.Products.Skip(64).Take(10).ToListAsync();

        foreach (var product in bestCollectionProducts)
        {
            var tag = new ProductsTagsEntity
            {
                TagId = 5,
                ProductArticleNumber = product.ArticleId
            };
            productTags.Add(tag);
        }

        foreach (var product in topSellersProducts)
        {
            var tag = new ProductsTagsEntity
            {
                TagId =3,
                ProductArticleNumber = product.ArticleId
            };
            productTags.Add(tag);
        }

        foreach (var product in newProducts)
        {
            var tag = new ProductsTagsEntity
            {
                TagId = 4,
                ProductArticleNumber = product.ArticleId
            };
            productTags.Add(tag);
        }

        await _context.ProductsTags.AddRangeAsync(productTags);
        await _context.SaveChangesAsync();
    }
}
