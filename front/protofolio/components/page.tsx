// 'use client'

// import { useState } from 'react'
// import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
// import { Button } from "@/components/ui/button"
// import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card"
// import { Input } from "@/components/ui/input"
// import { Textarea } from "@/components/ui/textarea"
// import { ScrollArea } from "@/components/ui/scroll-area"
// import { Separator } from "@/components/ui/separator"
// import { HeartIcon, MessageCircleIcon, HomeIcon, UserIcon, BellIcon, SettingsIcon, PlusIcon, BookmarkIcon } from "lucide-react"

// export function EnhancedFullPage() {
//   const [posts, setPosts] = useState([
//     {
//       id: 1,
//       author: 'John Doe',
//       avatar: '/placeholder-avatar.jpg',
//       content: 'Just learned about React hooks. Game changer!',
//       code: `const [count, setCount] = useState(0);
// useEffect(() => {
//   document.title = \`You clicked \${count} times\`;
// }, [count]);`,
//       likes: 42,
//       comments: [
//         { id: 1, author: 'Jane Smith', content: 'Totally agree! Hooks are amazing!' },
//         { id: 2, author: 'Bob Johnson', content: 'Can you share more about how you\'re using them?' }
//       ],
//       saved: false,
//       showComments: false,
//     },
//     {
//       id: 2,
//       author: 'Jane Smith',
//       avatar: '/placeholder-avatar.jpg',
//       content: 'Anyone have experience with GraphQL? Thinking of using it in my next project.',
//       code: `query {
//   user(id: "123") {
//     name
//     email
//     posts {
//       title
//     }
//   }
// }`,
//       likes: 23,
//       comments: [
//         { id: 1, author: 'Alice Williams', content: 'I\'ve used it in a few projects. It\'s great for reducing over-fetching!' },
//       ],
//       saved: false,
//       showComments: false,
//     },
//   ])
//   const [newPost, setNewPost] = useState('')
//   const [newPostCode, setNewPostCode] = useState('')

//   const handlePostSubmit = (e: React.FormEvent) => {
//     e.preventDefault()
//     if (newPost.trim()) {
//       setPosts([
//         {
//           id: posts.length + 1,
//           author: 'You',
//           avatar: '/placeholder-avatar.jpg',
//           content: newPost,
//           code: newPostCode,
//           likes: 0,
//           comments: [],
//           saved: false,
//           showComments: false,
//         },
//         ...posts
//       ])
//       setNewPost('')
//       setNewPostCode('')
//     }
//   }

//   const handleLike = (postId: number) => {
//     setPosts(posts.map(post =>
//       post.id === postId ? { ...post, likes: post.liked ? post.likes - 1 : post.likes + 1, liked: !post.liked } : post
//     ))
//   }

//   const handleSave = (postId: number) => {
//     setPosts(posts.map(post =>
//       post.id === postId ? { ...post, saved: !post.saved } : post
//     ))
//   }

//   const handleShowComments = (postId: number) => {
//     setPosts(posts.map(post =>
//       post.id === postId ? { ...post, showComments: !post.showComments } : post
//     ))
//   }

//   const handleAddComment = (postId: number, comment: string) => {
//     setPosts(posts.map(post =>
//       post.id === postId ? {
//         ...post,
//         comments: [...post.comments, { id: post.comments.length + 1, author: 'You', content: comment }]
//       } : post
//     ))
//   }

//   return (
//     <div className="flex h-screen bg-gray-100">
//       {/* Navbar */}
//       <nav className="flex flex-col justify-between w-16 bg-white border-r border-gray-200">
//         <div className="flex flex-col items-center pt-5 space-y-4">
//           <Button variant="ghost" size="icon" aria-label="Home">
//             <HomeIcon className="w-6 h-6" />
//           </Button>
//           <Button variant="ghost" size="icon" aria-label="Profile">
//             <UserIcon className="w-6 h-6" />
//           </Button>
//           <Button variant="ghost" size="icon" aria-label="Notifications">
//             <BellIcon className="w-6 h-6" />
//           </Button>
//           <Button variant="ghost" size="icon" aria-label="Saved Posts">
//             <BookmarkIcon className="w-6 h-6" />
//           </Button>
//         </div>
//         <div className="pb-5">
//           <Button variant="ghost" size="icon" aria-label="Settings">
//             <SettingsIcon className="w-6 h-6" />
//           </Button>
//         </div>
//       </nav>

//       {/* Main Content */}
//       <main className="flex-1 overflow-auto">
//         {/* Header */}
//         <header className="sticky top-0 z-10 bg-white border-b border-gray-200 p-4">
//           <h1 className="text-2xl font-bold">Programmer's Social Hub</h1>
//         </header>

//         <div className="max-w-2xl mx-auto p-4 space-y-4">
//           {/* Create Post Section */}
//           <Card>
//             <CardHeader>
//               <h2 className="text-lg font-semibold">Create a Post</h2>
//             </CardHeader>
//             <CardContent>
//               <form onSubmit={handlePostSubmit} className="space-y-4">
//                 <Textarea
//                   placeholder="What's on your mind?"
//                   value={newPost}
//                   onChange={(e) => setNewPost(e.target.value)}
//                   className="min-h-[100px]"
//                 />
//                 <Textarea
//                   placeholder="Add your code snippet here (optional)"
//                   value={newPostCode}
//                   onChange={(e) => setNewPostCode(e.target.value)}
//                   className="min-h-[100px] font-mono text-sm"
//                 />
//                 <Button type="submit">
//                   <PlusIcon className="w-4 h-4 mr-2" />
//                   Post
//                 </Button>
//               </form>
//             </CardContent>
//           </Card>

//           {/* Posts Section */}
//           {posts.map((post) => (
//             <Card key={post.id}>
//               <CardHeader className="flex flex-row items-center gap-4">
//                 <Avatar>
//                   <AvatarImage src={post.avatar} alt={post.author} />
//                   <AvatarFallback>{post.author[0]}</AvatarFallback>
//                 </Avatar>
//                 <div>
//                   <h3 className="text-lg font-semibold">{post.author}</h3>
//                   <p className="text-sm text-gray-500">Posted 2 hours ago</p>
//                 </div>
//               </CardHeader>
//               <CardContent className="space-y-4">
//                 <p>{post.content}</p>
//                 {post.code && (
//                   <pre className="bg-gray-100 p-4 rounded-md overflow-x-auto">
//                     <code className="text-sm">{post.code}</code>
//                   </pre>
//                 )}
//               </CardContent>
//               <CardFooter className="flex justify-between">
//                 <div className="flex space-x-2">
//                   <Button
//                     variant="ghost"
//                     className="flex items-center gap-2"
//                     onClick={() => handleLike(post.id)}
//                   >
//                     <HeartIcon className={`w-5 h-5 ${post.liked ? 'text-red-500 fill-red-500' : 'text-gray-500'}`} />
//                     <span>{post.likes} Likes</span>
//                   </Button>
//                   <Button
//                     variant="ghost"
//                     className="flex items-center gap-2"
//                     onClick={() => handleShowComments(post.id)}
//                   >
//                     <MessageCircleIcon className="w-5 h-5" />
//                     <span>{post.comments.length} Comments</span>
//                   </Button>
//                 </div>
//                 <Button
//                   variant="ghost"
//                   className="flex items-center gap-2"
//                   onClick={() => handleSave(post.id)}
//                 >
//                   <BookmarkIcon className={`w-5 h-5 ${post.saved ? 'text-blue-500 fill-blue-500' : 'text-gray-500'}`} />
//                   <span>{post.saved ? 'Saved' : 'Save'}</span>
//                 </Button>
//               </CardFooter>
//               {post.showComments && (
//                 <CardContent>
//                   <div className="space-y-4">
//                     {post.comments.map((comment) => (
//                       <div key={comment.id} className="flex items-start gap-4">
//                         <Avatar className="w-8 h-8">
//                           <AvatarFallback>{comment.author[0]}</AvatarFallback>
//                         </Avatar>
//                         <div className="flex-1">
//                           <p className="font-semibold">{comment.author}</p>
//                           <p className="text-sm text-gray-600">{comment.content}</p>
//                         </div>
//                       </div>
//                     ))}
//                     <form
//                       onSubmit={(e) => {
//                         e.preventDefault()
//                         const input = e.currentTarget.elements.namedItem('comment') as HTMLInputElement
//                         if (input.value.trim()) {
//                           handleAddComment(post.id, input.value)
//                           input.value = ''
//                         }
//                       }}
//                       className="flex gap-2"
//                     >
//                       <Input name="comment" placeholder="Add a comment..." className="flex-1" />
//                       <Button type="submit">Post</Button>
//                     </form>
//                   </div>
//                 </CardContent>
//               )}
//             </Card>
//           ))}
//         </div>
//       </main>

//       {/* Sidebar */}
//       <aside className="hidden md:block w-64 bg-white border-l border-gray-200 p-4">
//         <h2 className="text-lg font-semibold mb-4">Who to Follow</h2>
//         <ScrollArea className="h-[calc(100vh-8rem)]">
//           {[...Array(10)].map((_, i) => (
//             <div key={i} className="flex items-center justify-between mb-4">
//               <div className="flex items-center gap-2">
//                 <Avatar>
//                   <AvatarImage src={`/placeholder-avatar.jpg`} alt={`User ${i + 1}`} />
//                   <AvatarFallback>{`U${i + 1}`}</AvatarFallback>
//                 </Avatar>
//                 <div>
//                   <p className="font-medium">User {i + 1}</p>
//                   <p className="text-sm text-gray-500">@user{i + 1}</p>
//                 </div>
//               </div>
//               <Button variant="outline" size="sm">Follow</Button>
//             </div>
//           ))}
//         </ScrollArea>
//       </aside>
//     </div>
//   )
// }